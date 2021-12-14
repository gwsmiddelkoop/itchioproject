 using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    public TMP_Text Val;
    public TMP_Dropdown dropdownQuality;
    public TMP_Dropdown dropdownRes;
    public Slider volumeSlider;
    public float AudioVolume = 1f;

    Resolution[] resolutions;
    private void Start()
    {
        dropdownQuality.value = QualitySettings.GetQualityLevel();
        resolutions = Screen.resolutions;
        dropdownRes.ClearOptions();

        List<string> optionsRes = new List<string>();

        int currentResIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string optres = resolutions[i].width + "x" + resolutions[i].height;
            if (!optionsRes.Contains(optres))
            {
                optionsRes.Add(optres);
            }
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        dropdownRes.AddOptions(optionsRes);
        dropdownRes.value = currentResIndex;
        dropdownRes.RefreshShownValue();
    }
    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volumeSlider", volumeSlider.value);
        PlayerPrefs.Save();
    }
    public void SetResolution(int value)
    {
        Resolution res = resolutions[value];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void ChangeLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }
}
