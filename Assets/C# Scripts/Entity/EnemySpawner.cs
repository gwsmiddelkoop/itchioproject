using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> wave = new List<GameObject>();

    private void Awake()
    {
        StartCoroutine("WaveSpawner");
    }

    private IEnumerator WaveSpawner()
    {
        while (true)
        {
            for (int enemyIndex = 0; enemyIndex < wave.Count; enemyIndex++)
            {
                Instantiate(wave[enemyIndex]);

                yield return new WaitForSeconds(.5f);
            }

            yield return null;
        }
    }
}
