using Fueler.Bootstraps;
using Juce.CoreUnity.Scenes;
using Juce.SceneManagement.Loader;

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fueler.Content.Shared.Levels.ConfigurationAssets
{
    [CustomEditor(typeof(LevelConfigurationAsset))]
    public class LevelConfigurationAssetEditor : Editor
    {
        private const string LevelBootstrapSceneName = "AutoloadLevelBootstrap";

        private LevelConfigurationAsset actualTarget;

        private void OnEnable()
        {
            actualTarget = (LevelConfigurationAsset)target;
        }

        public override void OnInspectorGUI()
        {
            PlayDrawer();

            DrawDefaultInspector();
        }

        private void PlayDrawer()
        {
            if(Application.isPlaying)
            {
                return;
            }

            if(GUILayout.Button("Play"))
            {
                Play();
            }

            GUILayout.Space(5);
        }

        private void Play()
        {
            bool opened = EditorSceneLoader.TryOpenFromName(LevelBootstrapSceneName, OpenSceneMode.Single, out Scene scene);

            if(!opened)
            {
                UnityEngine.Debug.LogError($"Scene {LevelBootstrapSceneName} could not be opened");
                return;
            }

            AutoloadLevelBootstrap.SetLevelConfigurationAsset(actualTarget);

            bool autoLoadWasEnabled = SceneAutoLoader.LoadMasterOnPlay;

            if (autoLoadWasEnabled)
            {
                SceneAutoLoader.LoadMasterOnPlay = false;
            }

            EditorApplication.isPlaying = true;

            if (autoLoadWasEnabled)
            {
                SceneAutoLoader.LoadMasterOnPlay = true;
            }
        }
    }
}
