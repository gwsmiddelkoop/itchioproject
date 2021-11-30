using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatGroup
{
    [SerializeField] public StatGroupEntity entity = new StatGroupEntity();
    [SerializeField] public StatGroupWeapon weapon = new StatGroupWeapon();
    [SerializeField] public StatGroupProjectile projectile = new StatGroupProjectile();
}

[System.Serializable]
public class StatGroupEntity
{
    [Header("Genaral Options")] // All the general options/Fundamentals.
    public Sprite sprite;

    public int health;
    public int healthMax;

    [Header("Steering Options")] // All movement related Options.
    public bool canMove;
    public float speed;
}

[System.Serializable]
public class StatGroupWeapon
{
    [Header("Genaral Options")] // All the general options/Fundamentals.
    public Sprite sprite;

    [Header("Steering Options")] // All movement related Options.
    public float accuracy;

    [Header("Spawning Options")] // All projectile related options.
    public float fireRate;
    public int fireProjectileCount;
}

[System.Serializable]
public class StatGroupProjectile
{
    [Header("Genaral Options")] // All the general options/Fundamentals.
    public Sprite sprite;
    public float damage;

    [Header("Steering Options")] // All movement related Options.
    public bool moveable;
    public float speed;

    [Header("Hitable Options")] // Conditions for hitting.
    public bool canHitOtherProjectiles;

    [Header("On Hit")] // Actions to perform when hit.
    public ProjectileHitTypes hitType;
    public float hitAreaRadius;
    public bool destroyOnHit;
}