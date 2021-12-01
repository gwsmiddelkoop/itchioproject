using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Loader", menuName = "Loader/Loader")]
public class LoadButton : ScriptableObject
{
    public string SceneToload;
    public void LoadScene()
    {
        Time.timeScale = 1;
        FindObjectOfType<SceneLoader>().LoadScene(SceneToload);
    }
}
