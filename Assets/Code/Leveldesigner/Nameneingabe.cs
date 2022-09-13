using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Nameneingabe : MonoBehaviour
{
    public string Player_Name;
    public static string Saved_Name;
    

    public Text input;
    public Text loaded_Name;
    

    
    void Update()
    {
        Player_Name = PlayerPrefs.GetString("name", "kein Spieler");
        loaded_Name.text = Player_Name;
    }
    public void SetName()
    {
            Saved_Name = input.text;
            PlayerPrefs.SetString("name", Saved_Name);
    }
}
