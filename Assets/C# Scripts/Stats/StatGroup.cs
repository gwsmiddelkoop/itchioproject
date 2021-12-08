using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatGroup
{
    [SerializeField] public StatGroupName name = new StatGroupName();
    [SerializeField] public StatGroupSprite sprite = new StatGroupSprite();
    [SerializeField] public StatGroupHealth health = new StatGroupHealth();
    [SerializeField] public StatGroupContact contact = new StatGroupContact();
    [SerializeField] public StatGroupMovement movement = new StatGroupMovement();
    [SerializeField] public StatGroupWeapon weapon = new StatGroupWeapon();
    [SerializeField] public StatGroupAge age = new StatGroupAge();
}

[System.Serializable]
public class StatGroupName
{
    public bool usage;

    public string name;
}

[System.Serializable]
public class StatGroupSprite
{
    public bool usage;

    public Sprite sprite;
}

[System.Serializable]
public class StatGroupHealth
{
    public bool usage;

    public float health;
    public float healthMax;
}

[System.Serializable]
public class StatGroupContact
{
    public bool usage;

    public ContactTypes contactType;
    public float damage;
    public bool selfDestroy;
}

[System.Serializable]
public class StatGroupMovement
{
    public bool usage;

    public float speed;
}

[System.Serializable]
public class StatGroupWeapon
{
    public bool usage;

    public Sprite sprite;
    public float fireRate;
    public int projectileCount;
    public float accuracy;
    public StatTransGroup projectile;
}

[System.Serializable]
public class StatGroupAge
{
    public bool usage;
    public float age;
}