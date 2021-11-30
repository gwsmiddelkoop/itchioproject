using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class MovementPath : MonoBehaviour
{
    [Header("Node")]
    [SerializeField] private List<Vector2> pathNodes = new List<Vector2>();
    [SerializeField] private float nodeRadius;
    [SerializeField] private float nodeRandomDistance;

    [Header("Stats")]
    [SerializeField] private float movementSpeed;

    private int nodeIndex = 0;

    private Mover mover;

    private Transform trans;

    private void Awake()
    {
        trans = transform;
        mover = GetComponent<Mover>();
    }

    void Update()
    {
        if (pathNodes.Count >= nodeIndex)
        {
            if (((Vector2)trans.position - pathNodes[nodeIndex]).magnitude < nodeRadius)
            {
                if (nodeIndex + 1 < pathNodes.Count)
                {
                    nodeIndex++;
                }
            }

            mover.CalAndSetDisiredVelocity(pathNodes[nodeIndex] - (Vector2)trans.position, movementSpeed);
        }
    }
}
