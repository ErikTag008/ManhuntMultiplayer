using UnityEngine;

namespace Project.Assets._Project._Scripts.Cosmetics
{
    // A turntable view of the player model that wears an item, for the Customize screen: the catcher model for the
    // catcher slots, the runner model for the runner slot, with the other slots as equipped
    public interface ICosmeticPreview
    {
        // the live front view, rendered only while shown
        public Texture View { get; }

        public void ToggleShown(bool isShown);
        public void Show(CosmeticItem item);
        public void Rotate(float degrees);
        public void ResetRotation();
        // the item's Icon when it has one, otherwise a picture rendered once of the item on its model or weapon
        public Texture GetThumbnail(CosmeticItem item);
    }
}
