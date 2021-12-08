using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Static intance of the script.
    public static EnemyManager instance { get; private set; }

    // Own Variables.
    private List<GameObject> enemys = new List<GameObject>();

    void Start()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        instance = this;

        EventManager.instance.entitySpawned += AddEnemyToList;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetEnemys();
        }
    }

    private void AddEnemyToList(GameObject enemy)
    {
        enemys.Add(enemy);
    }

    public GameObject GetNearestEnemy(Vector2 position)
    {
        float distanceNearest = float.MaxValue;
        GameObject currentNearest = null;

        for (int enemyIndex = 0; enemyIndex < enemys.Count; enemyIndex++)
        {
            float currentDistance = (((Vector2)enemys[enemyIndex].transform.position) - position).magnitude;

            if (currentDistance < distanceNearest)
            {
                distanceNearest = currentDistance;

                currentNearest = enemys[enemyIndex];
            }
        }

        return currentNearest;
    }

    private void ResetEnemys()
    {
        for (int enemyIndex = 0; enemyIndex < enemys.Count; enemyIndex++)
        {
            Destroy(enemys[enemyIndex]);
        }

        enemys = new List<GameObject>();
    }
}
