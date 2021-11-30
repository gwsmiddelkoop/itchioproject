using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static intance of the script.
    public static GameManager instance { get; private set; }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        instance = this;
    }
}
