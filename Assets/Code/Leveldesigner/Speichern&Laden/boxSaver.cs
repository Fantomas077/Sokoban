
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



public class boxSaver : MonoBehaviour
{
    /////////////////////////////////////////////////////Properties///////////////////////////////////////////////////////////

    /// <summary>
    /// liefert Positionen aus dem Leveldesigner
    /// </summary>
    public List<float[]> saveVector { get; set; }

    /// <summary>
    /// Liefert GameObject Zuordnung aus dem Leveldesigner
    /// </summary>
    public List<int> saveInt { get; set; }

    /// <summary>
    /// Speichert Info's aus dem Leveldesigner als boxEntry-Liste
    /// </summary>
    public List<boxEntry> saveList { get; set; }

    /// <summary>
    /// Liefert boxEntry-Liste, um daraus Elemente zu instanziieren
    /// </summary>
    public List<boxEntry> loadList { get; set; }

    /// <summary>
    /// Ermöglicht Zuordnung
    /// </summary>
    public string levelName { get; set; }
    
    /// <summary>
    /// Liefert Speicherort
    /// </summary>
    public string dir
    {
        get
        {
            string _dir = @"C:\Games\SokobanReloaded\Levels\" + this.levelName + ".dat";
            return _dir;
        }

        private set { }
    }

    /// <summary>
    /// Dient der Fehlerauswertung bei Dateizugriff
    /// </summary>
    public string err { get; set; }


    //////////////////////////////////////////////////Methods/////////////////////////////////////////////////////////////////

    public void read()
    {
        try
        {
            FileStream stream = new FileStream(this.dir, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            using (stream)
            { loadList = (List<boxEntry>)formatter.Deserialize(stream); }
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
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Games\SokobanReloaded\Levels\");
            this.read();
            return;
        }
        catch (FileNotFoundException)
        {
            err = "Spieldaten fehlen im Zielverzeichnis!";
            return;
        }
        catch (IOException)
        {
            err = "Allgemeiner Lesefehler.";
            return;
        }
    }

    public void write()
    {

        //Schreiben
        try
        {
            FileStream stream;
            stream = new FileStream(this.dir, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            using (stream)
            { formatter.Serialize(stream, saveList); }
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
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Games\SokobanReloaded\Levels\");
            this.write();
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

    public void setName(string InputField)
    {
        if (InputField == "Save")
          this.levelName = GameObject.Find("SaveButton").GetComponent<SaveHandler>().SaveField.text;
        else if (InputField == "Load")
          this.levelName = GameObject.Find("LoadButton").GetComponent<LoadHandler>().LoadField.text;
    }
}