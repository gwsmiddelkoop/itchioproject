using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public GameObject overlay;
    public GameObject openButton;

    public GameObject testHolder;

    [Header("Sprites")]
    public Sprite tester;

    void Start()
    {
        openButton.SetActive(true);
        overlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchButton()
    {
        if (openButton.activeSelf)
        {
            openButton.SetActive(false);
        }
        else
        {
            openButton.SetActive(true);
        }
    }

    public void Open()
    {
        openButton.SetActive(false);
        overlay.SetActive(true);
    }

    public void Close()
    {
        overlay.SetActive(false);
        openButton.SetActive(true);
    }
}
