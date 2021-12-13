using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    // Serialized variables.
    [SerializeField] private int mouseButtonInt;
    [SerializeField] public List<StatTransGroupTemplate> towerTemplate = new List<StatTransGroupTemplate>();

    // Own private variables.
    private Transform trans;
    
    [Header("Place Tower")]
    public bool canPlace;
    public GameObject tempPanel;
    public ItemUI scriptRef;

    private void Awake()
    {
        trans = transform;

        tempPanel.SetActive(false);
    }

    void Update()
    {
        if (canPlace == true && Input.GetMouseButtonDown(mouseButtonInt))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        EventManager.instance.EntitySpawn(new StatTransGroupConverter().Convert(towerTemplate), trans, position);
    }

    public void TurnOn()
    {
        if (canPlace == true)
        {
            scriptRef.SwitchButton();
            canPlace = false;
            tempPanel.SetActive(false);
        }
        else
        {
            scriptRef.SwitchButton();
            canPlace = true;
            tempPanel.SetActive(true);
        }
    }
}
