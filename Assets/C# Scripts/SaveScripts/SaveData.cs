using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class SaveData
{
    public int BoolNameChange;
    public string Name;
    public SaveData(Save_Load _SL)
    {
        Name = _SL.Name;
        BoolNameChange = _SL.BoolNameChange;
    }
}