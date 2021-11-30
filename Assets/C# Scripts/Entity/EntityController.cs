using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private StatTransGroupTemplate statTransGroupTemplate;
    [SerializeField] private StatGroup stats;

    private StatTransGroup statTransGroup;

    private void Awake()
    {
        statTransGroup = new StatTransGroup(statTransGroupTemplate.statTransGroup);

        stats = statTransGroup.TransformStatGroup();

        SetUp();
    }

    private void SetUp()
    {
        if (stats.entity.sprite != null)
        {
            gameObject.AddComponent(typeof(SpriteRenderer));
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

            renderer.sprite = stats.entity.sprite;
        }

        if (TryGetComponent(out WeaponController weaponController))
        {
            weaponController.Initialize(stats);
        }
    }
}
