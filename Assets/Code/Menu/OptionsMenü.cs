using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenü : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown; //erstellt ein dropdown mit dem Text Mesh pro so das man datein einfügen kann

    public AudioMixer audioMixer; // der audio mixer für sound

    Resolution[] resolutions; //erstellet ein array für die resolutions(grafik einstellungen)
     void Start()
    {
        resolutions = Screen.resolutions; 

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>(); //erstellt eine liste die später gefüllt mit mit dem resolutions für die grafik einstellungen

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)  //check durch wie viele resolutions möglich sind und zählt nach
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);                 //
        resolutionDropdown.value = currentResolutionIndex;      //
        resolutionDropdown.RefreshShownValue();                 // füllt die dropdown anzeige
    } 

    public void SetResolution (int resolutionIndex)  
    {
        Resolution resolution = resolutions[resolutionIndex]; //lässt die grafik einstellungen einstellen

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //fullscreen einstellen
    }
    public void SetVolume(float volume) //musik lautstärke
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
