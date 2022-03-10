using Juce.Core.Visibility;
using Juce.CoreUnity.ViewStack.Entries;
using System;
using UnityEngine;

namespace Fueler.Content.Meta.Ui.LevelSelection
{
    public class LevelSelectionUiViewStackEntry : ViewStackEntry
    {
        public LevelSelectionUiViewStackEntry(
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
