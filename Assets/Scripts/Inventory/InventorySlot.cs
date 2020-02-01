using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;          // Reference to the Icon image

    Projectile item;  // Current item in the slot

    // Add item to the slot
    public void AddItem(Projectile newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    // Called when the item is pressed
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
