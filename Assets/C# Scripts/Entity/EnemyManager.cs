using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<GameObject> enemys = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetEnemys();
        }
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
