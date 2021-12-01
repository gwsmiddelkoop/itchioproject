using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private List<StatTransGroupTemplate> statTransGroupTemplates = new List<StatTransGroupTemplate>();
    [SerializeField] private StatGroup stats;

    private StatTransGroup statTransGroup;

    private void Awake()
    {
        statTransGroup = CombineAllTemplates(statTransGroupTemplates);

        stats = statTransGroup.TransformStatGroup();

        SetUp();
    }

    private StatTransGroup CombineAllTemplates(List<StatTransGroupTemplate> templates)
    {
        if (statTransGroupTemplates != null)
        {
            List<StatTransBase> list = new List<StatTransBase>();

            for (int i = 0; i < statTransGroupTemplates.Count; i++)
            {
                list.AddRange(statTransGroupTemplates[i].statTransGroup);
            }

            return new StatTransGroup(list);
        }

        return new StatTransGroup();
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
