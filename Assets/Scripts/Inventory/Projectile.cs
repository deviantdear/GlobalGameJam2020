using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Projectile")]
public class Projectile : ScriptableObject
{
    new public string name = "New Projectile";
    public Sprite icon = null;
    public bool isDefaultProjectile = false;
    public int itemCount;
    public GameObject prefab;
    public Color iconColor;
    public AudioClip soundEffect;

    public virtual bool Use()
    {
        if (itemCount <= 0)
            return false;
        //uses item, something happens
        itemCount--;
        Debug.Log("Using " + name);
        return true;
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this); //Calls the Remove method from inventory script
    }
}
