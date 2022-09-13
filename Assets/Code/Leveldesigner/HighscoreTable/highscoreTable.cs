
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class highscoreTable : MonoBehaviour
{
    /////////////////////////////////////////Arbeitsvariablen//////////////////////////////////////////////////////////////////////////////////////////
    private Transform entryContainer;
    private Transform entryTemplate;



    /////////////////////////////////////////Methoden//////////////////////////////////////////////////////////////////////////////////////////
        
    private void Awake() // baut die highscoreTable
    {
        string _LoadField = LoadHandler.levelNameDistribution;
        
        //////////////////////////////////////////////////////////////////
        ///Einlesen & aktuelle Spielerdaten ggf. hinzuf�gen
        /////////////////////////////////////////////////////////////////
        GameObject _eval = GameObject.Find("highscoreTable");
        saver _saver = _eval.AddComponent(typeof(saver)) as saver;
        _saver.read(_LoadField);

        // Aktuellen Score-Eintrag erzeugen & hinzuf�gen
        scoreEntry CurrentScore = new scoreEntry(LoadHandler.levelNameDistribution, Nameneingabe.Saved_Name, Player.Steps);
        _saver.scoreList.Add(CurrentScore);
        
        // Liste auf ROM schreiben & Liste im RAM l�schen
        _saver.write(_LoadField);
        _saver.scoreList.Clear();
        
        // Aktuelle Liste inkl. Spielerergebnis von ROM laden
        _saver.read(_LoadField);
        
        
        /////////////////////////////////////////////////////////////////
        ///Liste vorbereiten
        ////////////////////////////////////////////////////////////////

        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);
           
        ////////////////////////////////////////////////////////////////
        ///Liste bef�llen
        ///////////////////////////////////////////////////////////////
        
        float templateHeight = 70f;
        for (int i = 0; i < 11; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
            
            int rank = i+1;
            string rankString = rank.ToString() + ".";


            //Inhalte an posText �bergeben
            entryTransform.Find("posText").GetComponent<Text>().text = rankString;

            if (_saver.scoreList.Count >= rank)
                {   //Inhalte an nameText �bergeben
                    entryTransform.Find("scoreText").GetComponent<Text>().text = _saver.scoreList[i].points.ToString();
                    //Inhalte an nameText �bergen
                    entryTransform.Find("nameText").GetComponent<Text>().text = _saver.scoreList[i].player;

                }
            else
                {
                    //Inhalte an scoreText �bergeben
                    entryTransform.Find("scoreText").GetComponent<Text>().text = "---";
                    //Inhalte an nameText �bergen
                    entryTransform.Find("nameText").GetComponent<Text>().text = "---";
                }
            }
        }
    
    
    }
