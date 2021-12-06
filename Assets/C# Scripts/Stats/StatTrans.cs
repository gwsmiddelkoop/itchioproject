using UnityEngine;

public enum StatTypes
{
    NameUsage,
    Name,

    SpriteUsage,
    Sprite,

    HealthUsage,
    Health,
    HealthMax,

    ContactUsage,
    ContactType,
    ContactDamage,
    ContactSelfDestroy,

    MovementUsage,
    MovementSpeed,

    WeaponUsage,
    WeaponSprite,
    WeaponFireRate,
    WeaponProjectileCount,
    WeaponAccuracy,
    WeaponProjectile,

        WeaponTargetingUsage,
        WeaponTargetingType,
        WeaponTargetingRadius,
}

public enum ContactTypes
{
    Direct,
    Area,
}

public enum StatTransformTypes
{
    Add,
    Multiply,
    Divide,
}

// Base Stat
[System.Serializable]
public abstract class StatTransBase
{
    public abstract StatTypes statType { get; }
    public abstract StatGroup TransformStat(StatGroup stats);

    public virtual float CalculateTransformType(float numberA, float numberB, StatTransformTypes statTransformType)
    {
        switch (statTransformType)
        {
            case StatTransformTypes.Add:
                numberA += numberB;
                break;

            case StatTransformTypes.Multiply:
                numberA *= numberB;
                break;

            case StatTransformTypes.Divide:
                if (numberB != 0)
                {
                    numberA /= numberB;
                }
                break;
        }

        return numberA;
    }
}

// Name
public class StatTransNameUsage : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.NameUsage;

    public bool usage;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (usage)
        {
            stats.name.usage = true;
        }

        return stats;
    }
}

public class StatTransName : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.Name;

    public string name;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.name.name = name;

        return stats;
    }
}

// Sprite
public class StatTransSpriteUsage : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.SpriteUsage;

    public bool usage;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (usage)
        {
            stats.sprite.usage = true;
        }

        return stats;
    }
}

public class StatTransSprite : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.Sprite;

    public Sprite sprite;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.sprite.sprite = sprite;

        return stats;
    }
}

// Health
public class StatTransHealthUsage : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.HealthUsage;

    public bool usage;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (usage)
        {
            stats.health.usage = true;
        }

        return stats;
    }
}

public class StatTransHealth : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.Health;

    public StatTransformTypes transformType;

    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.health.health = CalculateTransformType(stats.health.health, amount, transformType);

        return stats;
    }
}

public class StatTransHealthMax : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.HealthMax;

    public StatTransformTypes transformType;

    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.health.healthMax = CalculateTransformType(stats.health.healthMax, amount, transformType);

        return stats;
    }
}

// Contact
public class StatTransContactUsage : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.ContactUsage;

    public bool usage;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (usage)
        {
            stats.contact.usage = true;
        }

        return stats;
    }
}

public class StatTransContactType : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.ContactType;

    public ContactTypes contactType;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.contact.contactType = contactType;

        return stats;
    }
}

public class StatTransContactDamage : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.ContactDamage;

    public StatTransformTypes transformType;

    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.contact.damage = CalculateTransformType(stats.contact.damage, amount, transformType);

        return stats;
    }
}

public class StatTransContactSelfDestroy : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.ContactSelfDestroy;

    public bool selfDestroy;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (!selfDestroy)
        {
            stats.contact.selfDestroy = false;
        }

        return stats;
    }
}

// Movement
public class StatTransMovementUsage : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.MovementUsage;

    public bool usage;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (usage)
        {
            stats.movement.usage = true;
        }

        return stats;
    }
}

public class StatTransMovementSpeed : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.MovementSpeed;

    public StatTransformTypes transformType;

    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.movement.speed = CalculateTransformType(stats.movement.speed, amount, transformType); ;

        return stats;
    }
}

// Weapon
public class StatTransWeaponUsage : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.WeaponUsage;

    public bool usage;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (usage)
        {
            stats.weapon.usage = true;
        }

        return stats;
    }
}

public class StatTransWeaponSprite : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.WeaponSprite;

    public Sprite sprite;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.weapon.sprite = sprite;

        return stats;
    }
}

public class StatTransWeaponFireRate : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.WeaponFireRate;

    public StatTransformTypes transformType;

    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.weapon.fireRate = CalculateTransformType(stats.weapon.fireRate, amount, transformType); ;

        return stats;
    }
}

public class StatTransWeaponProjectileCount : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.WeaponProjectileCount;

    public StatTransformTypes transformType;

    public int amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.weapon.projectileCount = (int)CalculateTransformType(stats.weapon.projectileCount, amount, transformType);

        return stats;
    }
}

public class StatTransWeaponAccuracy : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.WeaponAccuracy;

    public StatTransformTypes transformType;
    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.weapon.accuracy = CalculateTransformType(stats.weapon.accuracy, amount, transformType); ;

        return stats;
    }
}

public class StatTransWeaponProjectile : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.WeaponProjectile;

    public StatTransGroupTemplate projectile;

    public bool set;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (stats.weapon.projectile == null)
        {
            stats.weapon.projectile = new StatTransGroup();
        }

        if (set)
        {
            stats.weapon.projectile.stats = null;
            stats.weapon.projectile.AddStatsFromStatList(projectile.statTransGroup);
        }
        else
        {
            stats.weapon.projectile.AddStatsFromStatList(projectile.statTransGroup);
        }

        return stats;
    }
}
