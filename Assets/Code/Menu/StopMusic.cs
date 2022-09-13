using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMusic : MonoBehaviour
{
    void Update()
    {      
        if (SceneManager.GetActiveScene().name == "Game Designer")
            DoNotDestroy.instance.GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "Level1")
            DoNotDestroy.instance.GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "Level2")
            DoNotDestroy.instance.GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "Level3")
            DoNotDestroy.instance.GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "Level4")
            DoNotDestroy.instance.GetComponent<AudioSource>().Pause();
    }
    private void Awake()
    {

        if (SceneManager.GetActiveScene().name == "Menu")
            DoNotDestroy.instance.GetComponent<AudioSource>().Play();
    }
}



