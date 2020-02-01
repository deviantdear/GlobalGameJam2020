using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Projectile")]
public class Projectile : ScriptableObject
{
    new public string name = "New Projectile";
    public Sprite icon = null;
    public bool isDefaultProjectile = false;

    public virtual void Use()
    {
        //uses item, something happens

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this); //Calls the Remove method from inventory script
    }
}
