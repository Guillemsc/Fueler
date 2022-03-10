using Juce.Core.Visibility;
using Juce.CoreUnity.ViewStack.Entries;
using System;
using UnityEngine;

namespace Fueler.Content.Meta.Ui.Options
{
    public class OptionsUiViewStackEntry : ViewStackEntry
    {
        public OptionsUiViewStackEntry(
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
