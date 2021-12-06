using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class MovementPath : MonoBehaviour
{
    [Header("Node")]
    [SerializeField] private List<Vector2> nodes = new List<Vector2>();
    [SerializeField] private float nodeRadius;
    [SerializeField] private float nodeRandomDistance;
    [SerializeField] private bool beginAtNode;

    [Header("Stats")]
    [SerializeField] private float movementSpeed;

    private int nodeIndex = 0;
    private Mover mover;
    private Transform trans;

    private void Awake()
    {
        trans = transform;
        mover = GetComponent<Mover>();

        //RandomizeNodePositions();
    }

    private void Start()
    {
        if (beginAtNode && nodes != null && nodes.Count > 0)
        {
            trans.position = nodes[0];
        }
    }

    void Update()
    {
        if (nodes.Count > nodeIndex)
        {
            if (((Vector2)trans.position - nodes[nodeIndex]).magnitude < nodeRadius)
            {
                if (nodeIndex + 1 < nodes.Count)
                {
                    nodeIndex++;
                }
            }

            mover.CalAndSetDisiredVelocity(nodes[nodeIndex] - (Vector2)trans.position, movementSpeed);
        }
    }

    private void RandomizeNodePositions()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i] += new Vector2(Random.Range(-nodeRandomDistance, nodeRandomDistance), Random.Range(-nodeRandomDistance, nodeRandomDistance)) * Random.Range(0, 1);
        }
    }
}
