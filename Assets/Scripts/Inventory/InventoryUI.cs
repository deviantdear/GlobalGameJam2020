using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    int currentIndex = 0;

    InventorySlot[] slots;
    LauncherControl launcher;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        launcher = FindObjectOfType<LauncherControl>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SelectNext()
    {
        slots[currentIndex].UpdateState(false);
        currentIndex++;
        if (currentIndex >= inventory.items.Count)
            currentIndex = 0;
        slots[currentIndex].UpdateState(true);
        LoadAmmo();
    }

    public void SelectPrevious()
    {
        slots[currentIndex].UpdateState(false);
        currentIndex--;
        if (currentIndex < 0)
            currentIndex += inventory.items.Count;
        slots[currentIndex].UpdateState(true);
        LoadAmmo();
    }

    void LoadAmmo()
    {
        launcher.AmmoLoaded = inventory.items[currentIndex];
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        Debug.Log("upating UI");
    }


}
