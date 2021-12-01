using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "EnemyWave")]
public class EnemyWave : ScriptableObject
{
    [SerializeField] public List<GameObject> enemys = new List<GameObject>();
    [SerializeField] public float frequency;
}
