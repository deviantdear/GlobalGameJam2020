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
        background.color = item.iconColor;
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

        background.color = item.iconColor;
        if (active)
        {
            border.color = activeColor;
            return;
        }

        if (item.itemCount <= 0)
            border.color = usedColor;
        else
            border.color = normalColor;
    }
}
