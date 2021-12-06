using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCreator : MonoBehaviour
{
    [SerializeField] public List<StatTransGroupTemplate> statTransGroupTemplates = new List<StatTransGroupTemplate>();

    private StatTransGroup statTransGroup;

    void Start()
    {
        if (statTransGroup == null)
        {
            statTransGroup = CombineAllTemplates(statTransGroupTemplates);
        }

        EntityController controller = (EntityController)gameObject.AddComponent(typeof(EntityController));

        controller.Initialize(statTransGroup);

        Destroy(this);
    }

    public void Initialize(List<StatTransGroupTemplate> statTransGroupTemplates)
    {
        this.statTransGroupTemplates = statTransGroupTemplates;
    }

    public void Initialize(StatTransGroupTemplate statTransGroupTemplate)
    {
        statTransGroup = new StatTransGroup(statTransGroupTemplate.statTransGroup);
    }

    public void Initialize(StatTransGroup statTransGroup)
    {
        this.statTransGroup = statTransGroup;
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
}
