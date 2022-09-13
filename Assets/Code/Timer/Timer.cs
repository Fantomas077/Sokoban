using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int StartTimer = 0;
    [SerializeField]

    TextMeshProUGUI TxtTimer;

    void Start()
    {
        StartCoroutine(Pause());
        
    }

    // Update is called once per frame

    IEnumerator Pause()
    {
        
        while(StartTimer<1000)
        {
            yield return new WaitForSeconds(1f);
            StartTimer++;
            TxtTimer.text = "Time : " + StartTimer;

        }


    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    
}
