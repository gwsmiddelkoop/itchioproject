using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawnerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.entitySpawn += Spawn;
    }

    private void Spawn(StatTransGroup statTransGroup, Transform parent, Vector3 position)
    {
        GameObject entity = new GameObject("Entity", typeof(EntityCreator));
        entity.GetComponent<EntityCreator>().Initialize(statTransGroup);

        EventManager.instance.EntitySpawned(entity);

        entity.transform.parent = parent;
        entity.transform.position = position;
    }
}
