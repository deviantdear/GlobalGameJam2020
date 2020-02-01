using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    
    public bool beam;
    public int damage;
    public List<GameObject> projectileSpawns;
    public Projectile projectile;
    List<GameObject> m_lastProjectile = new List<GameObject>();

    [SerializeField] LauncherControl launcherControl;

    void Start()
    {
        // Trigger shooting system on launcher events
        launcherControl = GetComponent<LauncherControl>();
        launcherControl.onFire.AddListener(SpawnProjectiles);
        launcherControl.onLoaded.AddListener(LoadProjectile);
        launcherControl.onUnloaded.AddListener(UnloadProjectile);
    }


    void UnloadProjectile()
    {
        // Clear ref to projectile
        projectile = null;
    }

    void LoadProjectile()
    {
        // Set projectile ref from launcher controll
        projectile = launcherControl.AmmoLoaded;
    }

    void SpawnProjectiles()
    {

        if (!projectile)
        {
            return;
        }

        //Clears last projectiles spawned
        m_lastProjectile.Clear();

        for(int i = 0; i < projectileSpawns.Count; i++)
        {
            if (projectileSpawns[i])
            {
                GameObject proj = Instantiate(projectile.Use(), projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;
                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], projectileSpawns[i].transform.forward, damage);
            }
        }
    }

    
}
