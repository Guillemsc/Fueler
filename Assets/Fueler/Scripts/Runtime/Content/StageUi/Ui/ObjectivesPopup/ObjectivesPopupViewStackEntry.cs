using Juce.Core.Visibility;
using Juce.CoreUnity.ViewStack.Entries;
using System;
using UnityEngine;

namespace Fueler.Content.StageUi.Ui.ObjectivesPopup
{
    public class ObjectivesPopupViewStackEntry : ViewStackEntry
    {
        public ObjectivesPopupViewStackEntry(
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
