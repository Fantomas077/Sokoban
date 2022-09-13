using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObject : MonoBehaviour
{
    public int objectnum;
    private GameDesignerManager Manager;

    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("GameDesignerManager").GetComponent<GameDesignerManager>();
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(this.gameObject);
            Manager.Buttons[objectnum].quantity++;
            Manager.Buttons[objectnum].quantityText.text = Manager.Buttons[objectnum].quantity.ToString();
            Manager.current_objectpos.RemoveAt(Manager.current_objectpos.Count - 1); // zuletzt plazierte Position wird entfernt 
            Manager.current_obj.RemoveAt(Manager.current_obj.Count - 1); // zuletzt plaziertes Element wird entfernt 
        }
    }
}
    
