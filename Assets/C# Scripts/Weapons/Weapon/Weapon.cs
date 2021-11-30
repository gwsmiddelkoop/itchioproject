using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Weapon
{
    // Variables about stats.
    private StatTransGroup statTransGroup;
    private StatGroup stats;

    // Script connections.
    private WeaponController controller;

    // Own private variables.
    private Transform trans;
    private bool canFire;

    public Weapon(WeaponController controller, StatGroup stats)
    {
        this.controller = controller;
        this.trans = controller.transform;

        this.stats = stats;

        controller.StartCoroutine(FireTimer());
    }

    public void CanFire(bool canFire)
    {
        this.canFire = canFire;
    }

    IEnumerator FireTimer()
    {
        while (true)
        {
            if (canFire)
            {
                Fire();

                yield return new WaitForSeconds(1f / stats.weapon.fireRate);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Fire()
    {
        for (int i = 0; i < stats.weapon.fireProjectileCount; i++)
        {
            CreateProjectile();
        }
    }

    private void CreateProjectile()
    {
        GameObject projectileObject = new GameObject("Projectile", typeof(Projectile));
        projectileObject.transform.parent = controller.transform;

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Initialize(stats.projectile);
        projectileObject.transform.position = trans.position;
    }
}
