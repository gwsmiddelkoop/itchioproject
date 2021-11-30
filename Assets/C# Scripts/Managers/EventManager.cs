using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Static intance of the script.
    public static EventManager instance { get; private set; }

    // Delegates and their events.
    public delegate void EmptyDelegate();
    public event EmptyDelegate OnClicked;

    public delegate void GameObjectDelegate(GameObject gameObject);
    public event GameObjectDelegate enemySpawned;
    public event GameObjectDelegate towerSpawned;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        instance = this;
    }

    public void EnemySpawned(GameObject enemy)
    {
        if (enemySpawned != null)
            enemySpawned(enemy);
    }

    public void TowerSpawned(GameObject tower)
    {
        if (towerSpawned != null)
            towerSpawned(tower);
    }
}
