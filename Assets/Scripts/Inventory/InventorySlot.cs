using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;          // Reference to the Icon image
    public Image background;
    public Image border;
    public TextMeshProUGUI itemCount;
    public bool active = false;
    Projectile item;  // Current item in the slot

    [SerializeField] Color activeColor;
    [SerializeField] Color normalColor;
    [SerializeField] Color usedColor;


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
        itemCount.text = item.itemCount.ToString();
        icon.enabled = true;
        border.color = item.iconColor;
    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UpdateState(bool newState)
    {
        active = newState;
        UpdateBackground();
    }

    public void UpdateBackground()
    {

        if (active)
        {
            background.color = activeColor;
            return;
        }
        if (item.itemCount <= 0)
            background.color = usedColor;
        else
            background.color = normalColor;


    }
}
