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
            statTransGroup = new StatTransGroupConverter().Convert(statTransGroupTemplates);
        }

        EntityController controller = (EntityController)gameObject.AddComponent(typeof(EntityController));

        controller.Initialize(statTransGroup);

        Destroy(this);
    }

    public void Initialize(StatTransGroup statTransGroup)
    {
        this.statTransGroup = statTransGroup;
    }
}
