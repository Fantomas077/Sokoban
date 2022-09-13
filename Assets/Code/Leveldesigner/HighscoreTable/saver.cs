using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;

public class saver : MonoBehaviour
{
    /////////////////////////////////////////Properties//////////////////////////////////////////////////////////////////////////////////////////
    public string levelID { get; set; }
    
    public string err { get; set; }

    public double points { get; set; }

    public string player { get; set; }

    public List<scoreEntry> scoreList { get; set; } = new List<scoreEntry>();


    /////////////////////////////////////////Methoden//////////////////////////////////////////////////////////////////////////////////////////
    private void Start()
    {
        scoreList = new List<scoreEntry>();
    }
        
    /// <summary>
    /// fügt CurrentEntry hinzu
    /// </summary>
    /// <param name="scoreList"> Liste, zu der hinzugefügt werden soll </param>
        
    /// <summary>
    /// Liest highscoretable.dat aus Zielverzeichnis aus, und organisiert die scoreEntry-Liste
    /// </summary>
    public void read(string _levelID)
    {
        string _dir = @"C:\Games\SokobanReloaded\Savegames\" + _levelID;
        List<scoreEntry> _scoreList = new List<scoreEntry>();
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Einlesen
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        try
        {
            FileStream stream = new FileStream(_dir, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            using (stream)
            { _scoreList = (List<scoreEntry>)formatter.Deserialize(stream); }
            stream.Close();
        }
        catch (System.Security.SecurityException)
        {
            err = "Keinen Zugriff auf die Datei.";
            
            return;
        }
        catch (PathTooLongException)
        {
            err = "Pfad ist zu lang.";
            return;
        }
        catch (DirectoryNotFoundException)
        {
            // Verzeichnis erstellen
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Games\SokobanReloaded\Savegames");
            this.read(_levelID);
            return;
        }
        catch (FileNotFoundException)
        {
            this.write(_levelID);
            return;
        }
        catch (IOException)
        {
            err = "Allgemeiner Lesefehler.";
            return;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Sortieren und kuerzen [In Bearbeitungsliste _scoreList]
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        this.scoreList = _scoreList;
                
    }
    
    /// <summary>
    /// Schreibt highscoretable.dat in Zielverzeichnis
    /// </summary>
    public void write (string _levelID)
    {
        string _dir = @"C:\Games\SokobanReloaded\Savegames\" + _levelID;

        // this.scoreList Sortieren
        scoreList = scoreList.OrderBy(scoreEntry => scoreEntry.points).ToList();
        
        // this. scoreList Kuerzen
        if (scoreList.Count > 11)
        {
            for (int i = 11; i < scoreList.Count - 1; i++)
            {
                scoreList.RemoveAt(i);
            }
        }

        //Schreiben
        try
        {
            FileStream stream;
            stream = new FileStream(_dir, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            using (stream)
            { formatter.Serialize(stream, scoreList); }
            stream.Close();

        }
        catch (System.Security.SecurityException)
        {
            err = "Keinen Zugriff auf die Datei.";
            return;
        }
        catch (DirectoryNotFoundException)
        {
            // Verzeichnis erstellen
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Games\SokobanReloaded\Savegames");
            this.write(_levelID);
            return;
        }
        catch (PathTooLongException)
        {
            err = "Pfad ist zu lang.";
            return;
        }
        catch (IOException)
        {
            err = "Allgemeiner Lesefehler.";
            return;
        }

        
    }
   
    
       
}