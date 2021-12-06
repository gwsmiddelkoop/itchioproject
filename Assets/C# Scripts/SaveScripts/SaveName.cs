using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveName : MonoBehaviour
{
    #region UI Objects
    [SerializeField] Save_Load _SL;
    [SerializeField] GameObject CN;
    [SerializeField] TMP_InputField Name;
    [SerializeField] TMP_Text NameTXT;
    #endregion
    public void Save()
    {
        _SL.Name = Name.text;
        _SL.BoolNameChange++;
    }
    public void ChangeName()
    {
        _SL.BoolNameChange = 0;
    }
    private void Update()
    {
        NameTXT.text = _SL.Name;
        if (_SL.BoolNameChange != 0)
        {
            CN.SetActive(false);
        }
    }
}