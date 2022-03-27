using Juce.Core.Visibility;
using Juce.CoreUnity.ViewStack.Entries;
using System;
using UnityEngine;

namespace Fueler.Content.Meta.Ui.Accessibility
{
    public class AccessibilityUiViewStackEntry : ViewStackEntry
    {
        public AccessibilityUiViewStackEntry(
            Type id,
            Transform transform,
            IVisible visible,
            bool isPopup,
            params ViewStackEntryRefresh[] refreshList
            ) : base(id, transform, visible, isPopup, refreshList)
        {

        }
    }
}
