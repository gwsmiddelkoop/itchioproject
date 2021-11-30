using UnityEngine;

public enum StatTypes
{
    Accuracy,
    CanHitOtherProjectiles,
    Damage,
    DestroyOnHit,
    FireProjectileCount,
    FireRate,
    Moveable,
    ProjectileHitType,
    Speed,
    Sprite,
}

public enum ProjectileHitTypes
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

public enum StatSpriteTypes
{
    Entity,
    Weapon,
    Projectile,
}

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


public class StatTransAccuracy : StatTransBase{
    [HideInInspector] public override StatTypes statType => StatTypes.Accuracy;

    public StatTransformTypes transformType;
    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.weapon.accuracy = CalculateTransformType(stats.weapon.accuracy, amount, transformType); ;

        return stats;
    }
}

public class StatTransCanHitOtherProjectiles : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.CanHitOtherProjectiles;

    public bool canHitOtherProjectiles;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (canHitOtherProjectiles)
        {
            stats.projectile.canHitOtherProjectiles = true;
        }

        return stats;
    }
}

public class StatTransDamage : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.Damage;

    public StatTransformTypes transformType;

    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.projectile.damage = CalculateTransformType(stats.projectile.damage, amount, transformType);

        return stats;
    }
}

public class StatTransDestroyOnHit : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.DestroyOnHit;

    public bool destroyOnHit;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (!destroyOnHit)
        {
            stats.projectile.destroyOnHit = false;
        }

        return stats;
    }
}

public class StatTransFireProjectileCount : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.FireProjectileCount;

    public StatTransformTypes transformType;

    public int amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.weapon.fireProjectileCount = (int)CalculateTransformType(stats.weapon.fireProjectileCount, amount, transformType);

        return stats;
    }
}

public class StatTransFireRate : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.FireRate;

    public StatTransformTypes transformType;

    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.weapon.fireRate = CalculateTransformType(stats.weapon.fireRate, amount, transformType); ;

        return stats;
    }
}

public class StatTransMoveable : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.Moveable;

    public bool moveable;

    public override StatGroup TransformStat(StatGroup stats)
    {
        if (moveable)
        {
            stats.projectile.moveable = true;
        }

        return stats;
    }
}

public class StatTransProjectileHitType : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.ProjectileHitType;

    public ProjectileHitTypes projectileHitType;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.projectile.hitType = projectileHitType;

        return stats;
    }
}

public class StatTransSpeed : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.Speed;

    public StatTransformTypes transformType;

    public float amount;

    public override StatGroup TransformStat(StatGroup stats)
    {
        stats.projectile.speed = CalculateTransformType(stats.projectile.speed, amount, transformType); ;

        return stats;
    }
}

public class StatTransSprite : StatTransBase
{
    [HideInInspector] public override StatTypes statType => StatTypes.Sprite;

    public Sprite sprite;

    public StatSpriteTypes spriteType;

    public override StatGroup TransformStat(StatGroup stats)
    {
        switch (spriteType)
        {
            case StatSpriteTypes.Entity:
                stats.entity.sprite = sprite;
                break;
            case StatSpriteTypes.Weapon:
                stats.weapon.sprite = sprite;
                break;
            case StatSpriteTypes.Projectile:
                stats.projectile.sprite = sprite;
                break;
        }

        return stats;
    }
}
