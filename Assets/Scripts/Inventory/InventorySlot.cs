using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;          // Reference to the Icon image
    public TextMeshProUGUI itemCount;
    Projectile item;  // Current item in the slot


    void Start()
    {
        if (item != null)
            itemCount.SetText(item.itemCount.ToString());
    }
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
        if (item != null && item.itemCount > 0)
        {
            item.Use();

        }
    }
}
