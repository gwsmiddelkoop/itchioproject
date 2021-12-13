using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "EnemyWave")]
public class EnemyWave : ScriptableObject
{
    [SerializeField] public List<StatTransGroupTemplate> enemys = new List<StatTransGroupTemplate>();
    [SerializeField] public float frequency;
}
