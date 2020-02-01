using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than once instance of Inventory found");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Projectile> items = new List<Projectile>();

    public bool Add(Projectile p_item)
    {
        if (!p_item.isDefaultProjectile) 
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(p_item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Projectile p_item)
    {
        items.Remove(p_item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
