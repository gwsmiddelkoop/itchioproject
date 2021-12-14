using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Options _Options;
    public void LoadScene(LoadButton _LB)
    {
        _LB.LoadScene();
    }
    public void SetVolume(Options opt)
    {
        opt.SetVolume();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
