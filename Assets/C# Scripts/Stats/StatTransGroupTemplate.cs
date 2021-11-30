using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatTransGroupTemplate", menuName = "StatTransGroupTemplate")]
public class StatTransGroupTemplate : ScriptableObject
{
    [SerializeReference, SerializeReferenceButton] public List<StatTransBase> statTransGroup;
}