using Juce.CoreUnity.Guizmos;
using Juce.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Fueler.Content.Stage.General.Actors.FollowPath
{
    public class FollowPathActor : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private FollowPathMode mode = FollowPathMode.Circular;
        [SerializeField] private float timeBetweenPoints = 2.0f;
        [SerializeField] private AnimationCurve easing = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [Header("Setup")]
        [SerializeField] private Transform target = default;
        [SerializeField] private List<Transform> pathPoints = default;

        private void Awake()
        {
            StartFolowPath();
        }

        private void StartFolowPath()
        {
            if (pathPoints.Count <= 1)
            {
                return;
            }

            ISequenceTween sequence = JuceTween.Sequence();

            bool firstPoint = true;
            foreach (Transform point in pathPoints)
            {
                if (point == null)
                {
                    return;
                }

                if (firstPoint)
                {
                    firstPoint = false;
                    continue;
                }

                sequence.Append(target.TweenPosition(point.position, timeBetweenPoints));
            }

            switch(mode)
            {
                default:
                case FollowPathMode.Circular:
                    {
                        sequence.Append(target.TweenPosition(pathPoints[0].position, timeBetweenPoints));
                    }
                    break;

                case FollowPathMode.Yoyo:
                    {
                        for(int i = pathPoints.Count - 2; i >= 0; --i)
                        {
                            Transform point = pathPoints[i];

                            sequence.Append(target.TweenPosition(point.position, timeBetweenPoints));
                        }
                    }
                    break;
            }

            sequence.SetLoops(int.MaxValue, ResetMode.InitialValues);
            sequence.SetEase(easing);

            sequence.Play();
        }

        private void OnDrawGizmos()
        {
            if(pathPoints.Count <= 1)
            {
                return;
            }

            Transform lastPoint = null;
            foreach (Transform point in pathPoints)
            {
                if(point == null)
                {
                    return;
                }

                if(lastPoint == null)
                {
                    lastPoint = point;
                    continue;
                }

                GizmosUtils.DrawLine(lastPoint.transform.position, point.transform.position, Color.red);

                lastPoint = point;
            }

            if(mode == FollowPathMode.Circular)
            {
                GizmosUtils.DrawLine(lastPoint.position, pathPoints[0].position, Color.red);
            }
        }
    }
}
