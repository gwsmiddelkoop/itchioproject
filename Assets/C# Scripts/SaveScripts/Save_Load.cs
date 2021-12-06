using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using TMPro;
public class Save_Load : MonoBehaviour
{ 
    public int BoolNameChange;
    public string Name;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SaveData()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();

        Name = data.Name;
        BoolNameChange = data.BoolNameChange;
    }
}
