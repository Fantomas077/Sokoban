using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public Player main;
    private bool player_Input;
    public GameObject Button;

    public  bool GameIsPaused = true;

    private void Start()
    {
        Button.SetActive(false);
    }


    void Update()
    {
        StartCoroutine(couroutine());

        if (this.GameIsPaused == true)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveInput.Normalize();
            if (moveInput.sqrMagnitude > 0.5)
            {
                if (player_Input)
                {
                    player_Input = false;
                    main.Move(moveInput);
                    Button.SetActive(LevelComplete());
                }


            }
            else
            {
                player_Input = true;
            }

        }
    }

    IEnumerator couroutine()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                GameIsPaused = false;
            else
                GameIsPaused = true;
            yield return new WaitForSeconds(0.8F);
        }
    }











    bool LevelComplete()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        foreach (var box in boxes)
        {
            if (box.OnCross == false)
            {
                return false;
            }
        }
        return true;
    }
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}


    

   

    



