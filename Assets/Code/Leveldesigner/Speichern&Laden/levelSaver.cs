using System.Collections.Generic;
using UnityEngine;


public class levelSaver : MonoBehaviour
{
         
    public void saveLevel()
    {
        // Init boxSaver an GameDesignerManager
        boxSaver _boxsaver = GameObject.Find("GameDesignerManager").AddComponent(typeof(boxSaver)) as boxSaver;

        // Vorbereitung        
        _boxsaver.setName("Save"); // Speicherordner zuweisen
        _boxsaver.saveList = new List<boxEntry>();
        List<float[]> _saveVector = new List<float[]>();
        
        //Informationen aus GameDesignerManager holen
        if (_boxsaver.saveVector != null)
            _boxsaver.saveVector.Clear(); // ggf. leeren
        if (_boxsaver.saveInt != null)
            _boxsaver.saveInt.Clear();    // ggf. leeren
        GameObject GDM = GameObject.Find("GameDesignerManager");
        
        // Vector2 transformieren
        foreach (Vector2 vector in GDM.GetComponent<GameDesignerManager>().current_objectpos)
        {
            float[] seriVector = new float[2];
            seriVector[0] = vector.x;
            seriVector[1] = vector.y;
            _saveVector.Add(seriVector);
        }

        _boxsaver.saveVector = _saveVector;
        _boxsaver.saveInt = GDM.GetComponent<GameDesignerManager>().CurrentObjectInt;
        
        //Serialisierbare Objektliste bauen
        for (int i = 0; i < _boxsaver.saveInt.Count; i++)
        {
            boxEntry obj = new boxEntry();
            obj.Vector = _boxsaver.saveVector[i];
            obj._gameObject = _boxsaver.saveInt[i];
            _boxsaver.saveList.Add(obj);

        }
                  
        // Datei schreiben
        _boxsaver.write();
    }

    
}