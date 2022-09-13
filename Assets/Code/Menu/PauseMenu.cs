using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    void Update() //schaut ob die escape taste gedrückt wurde
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) //wenn das spiel pauseirt ist, schaltet er das pause menü aus
            {
                Resume();
            }
            else  //oder pausiert es wenn das pause menü nicht offen war
            {
                Pause();
            }           
        }
    }
    public void Resume()  //setzt das pause menü auf false um zum spiel zurück zu kommen
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);  //passuert das spiel wenn taste gedrückt wird
        Time.timeScale = 0F;
        GameIsPaused = true;
    }

    public void LoadMenu(string scene_name) //lädt das haupt menü
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene_name);
    }

    public void QuitGame()  //beendet das spiel
    {
        Application.Quit();
    }


}
