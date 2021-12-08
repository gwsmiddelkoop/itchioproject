using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyWave> waves = new List<EnemyWave>();

    private Transform trans;

    private void Awake()
    {
        trans = transform;
    }

    private void Start()
    {
        StartCoroutine("WaveSpawner");
    }

    private IEnumerator WaveSpawner()
    {
        while (true)
        {
            for (int waveIndex = 0; waveIndex < waves.Count; waveIndex++)
            {
                for (int enemyIndex = 0; enemyIndex < waves[waveIndex].enemys.Count; enemyIndex++)
                {
                    StatTransGroup currentStatTransGroup = new StatTransGroupConverter().Convert(waves[waveIndex].enemys[enemyIndex].statTransGroup);

                    EventManager.instance.EntitySpawn(currentStatTransGroup, trans, Vector3.zero);

                    yield return new WaitForSeconds(waves[waveIndex].frequency);
                }
            }

            yield return null;
        }
    }
}
