using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    
    public void LoadScene(string scene_name)
    {
        Player.Steps = 0;
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene(scene_name);       
    }
    public void QuitGame()  //beendet das spiel
    {
        Application.Quit();
    }
}
