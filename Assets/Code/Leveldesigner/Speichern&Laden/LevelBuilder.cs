using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    //////////////////////////////////////////////////////Arbeitsvariablen///////////////////////////////////////////////////////

    GameDesignerManager x;

    //////////////////////////////////////////////////////Methoden///////////////////////////////////////////////////////



    void Start()
    {
        x = GameObject.FindGameObjectWithTag("GameDesignerManager").GetComponent<GameDesignerManager>();

    }

    public void build()
    {
        // Vorbereiten
        boxSaver boxsaver = GameObject.Find("GameDesignerManager").AddComponent(typeof(boxSaver)) as boxSaver;
        boxsaver.setName("Load"); // Ordnername festlegen
        boxsaver.loadList = new List<boxEntry>();
        
        // Auslesen und Füllen
        boxsaver.read();

        // Elemente instanziieren
        foreach (var item in boxsaver.loadList)
        {
            Vector2 newVector = new Vector2(Mathf.Round(item.Vector[0]), Mathf.Round(item.Vector[1]));
            RaycastHit2D Hit = Physics2D.Raycast(newVector, Vector2.zero, Mathf.Infinity, GameObject.Find("GameDesignerManager").GetComponent<GameDesignerManager>().Layer);

            if (Hit.collider == null)
            {
                Instantiate(x.Prefabs[item._gameObject], newVector, Quaternion.identity);
                GameObject.Find("GameDesignerManager").GetComponent<GameDesignerManager>().current_objectpos.Add(newVector);
                GameObject.Find("GameDesignerManager").GetComponent<GameDesignerManager>().CurrentObjectInt.Add(item._gameObject);
            }
        }
    }
}