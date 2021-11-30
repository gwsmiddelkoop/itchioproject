using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WeaponTargetingTypes
{
    player,
    ai,
    test,
}

public class WeaponTargeting
{
    public bool GetTargeting(WeaponTargetingTypes targetingType)
    {
        switch (targetingType)
        {
            case WeaponTargetingTypes.player:
                return TargetingPlayer();

            case WeaponTargetingTypes.ai:
                return TargetingAi();

            case WeaponTargetingTypes.test:
                return TargetingTest();
        }

        return false;
    }

    public bool TargetingPlayer()
    {
        bool result = false;

        if (Input.GetKey(KeyCode.Space))
        {
            result = true;
        }

        if (!Input.GetKey(KeyCode.Space))
        {
            result = false;
        }

        return result;
    }

    public bool TargetingAi()
    {
        bool result = false;

        return result;
    }

    public bool TargetingTest()
    {
        return true;
    }
}

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponTargetingTypes targetingType;

    private WeaponTargeting targeting = new WeaponTargeting();

    private StatGroup stats;

    private Weapon weapon;

    private Transform trans;

    public void Initialize(StatGroup stats)
    {
        trans = transform;

        this.stats = stats;

        CreateWeapon(stats);
    }

    private void Update()
    {
        weapon.CanFire(targeting.GetTargeting(targetingType));
    }

    public void CreateWeapon(StatGroup stats)
    {
        weapon = new Weapon(this, stats);
    }
}