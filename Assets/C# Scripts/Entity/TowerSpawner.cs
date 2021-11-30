using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    // Serialized variables.
    [SerializeField] private int mouseButtonInt;
    [SerializeField] private GameObject towerPrefab;

    // Own private variables.
    private Transform trans;

    private void Awake()
    {
        trans = transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(mouseButtonInt))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject tower = Instantiate(towerPrefab, trans);

        tower.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
