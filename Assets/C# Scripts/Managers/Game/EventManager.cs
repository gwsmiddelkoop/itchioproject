using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Static intance of the script.
    public static EventManager instance { get; private set; }

    // Delegates and their events.
    public delegate void EmptyDelegate();

    public delegate void StatTransGroupDelegate(StatTransGroup statTransGroup, Transform parent, Vector3 position);
    public event StatTransGroupDelegate entitySpawn;

    public delegate void GameObjectDelegate(GameObject gameObject);
    public event GameObjectDelegate entitySpawned;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        instance = this;
    }

    public void EntitySpawn(StatTransGroup statTransGroup, Transform parent, Vector3 position)
    {
        if (entitySpawn != null)
            entitySpawn(statTransGroup, parent, position);
    }

    public void EntitySpawned(GameObject gameObject)
    {
        if (entitySpawned != null)
            entitySpawned(gameObject);
    }
}
