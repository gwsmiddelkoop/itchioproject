using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> wave = new List<GameObject>();

    [SerializeField] private Vector2 spawnPosition;

    private void Start()
    {
        StartCoroutine("WaveSpawner");
    }

    private IEnumerator WaveSpawner()
    {
        while (true)
        {
            for (int enemyIndex = 0; enemyIndex < wave.Count; enemyIndex++)
            {
                EventManager.instance.EnemySpawned(Instantiate(wave[enemyIndex], spawnPosition, Quaternion.identity));

                yield return new WaitForSeconds(.5f);
            }

            yield return null;
        }
    }
}
