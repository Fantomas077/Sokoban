using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public int objectnum;
    public int quantity;
    public Text quantityText;
    public bool clicked = true;
    public GameDesignerManager Manager;

    
    
    public void Start()
    {
        quantityText.text = quantity.ToString();
        Manager = GameObject.FindGameObjectWithTag("GameDesignerManager").GetComponent<GameDesignerManager>(); 
    }
    public void ClickedButton()
    {
        
        if (quantity > 0)
        {
                Vector2 Mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 Worldposition = Camera.main.ScreenToWorldPoint(Mouseposition);
            clicked = true;
                Instantiate(Manager.DestroyItem[objectnum], new Vector2(Worldposition.x, Worldposition.y), Quaternion.identity);
                quantity--;
                quantityText.text = quantity.ToString();
                Manager.CurrentButtonPressed = objectnum;
            
        }
        
        else
        {
            if (objectnum == 0)
            {
                quantityText.text = "Kisten sind leer !";
            }
            if (objectnum == 1)
            {
                quantityText.text = "nur ein Haupcharakter !";
            }
            if (objectnum == 2)
            {
                quantityText.text = "Wände sind leer !";
            }
            if (objectnum == 3)
            {
                quantityText.text = "Kreuze sind leer !";
            }
        }

    }
    


}
