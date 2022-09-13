using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDesignerManager : MonoBehaviour
{
    public ItemController[] Buttons;
    public GameObject[] Prefabs;
    public GameObject[] DestroyItem;
    public LayerMask Layer;
    public List<Vector2> current_objectpos;
    public List<GameObject> current_obj;
    public int CurrentButtonPressed;
    public List<int> CurrentObjectInt;
    public GameObject NextLevelButton;

    private void Start()
    {
        NextLevelButton.SetActive(false);
    }
    private void Update()
    {
        if (GameObject.Find("GameDesignerManager").GetComponent<GameDesignerManager>().CurrentObjectInt.Count > 0)
            NextLevelButton.SetActive(LevelComplete());


        Vector2 Mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 Worldposition = Camera.main.ScreenToWorldPoint(Mouseposition);
        
            if(Input.GetMouseButtonDown(0) && Buttons[CurrentButtonPressed].clicked)
            {
                
                RaycastHit2D Hit = Physics2D.Raycast(Worldposition, Vector2.zero, Mathf.Infinity, Layer);

                if (Hit.collider == null)
                {
                    Instantiate(Prefabs[CurrentButtonPressed], new Vector2(Mathf.Round(Worldposition.x), Mathf.Round(Worldposition.y)), Quaternion.identity);
                    Buttons[CurrentButtonPressed].clicked = false;
                    current_objectpos.Add(Worldposition);
                    current_obj.Add(Prefabs[CurrentButtonPressed]);
                    CurrentObjectInt.Add(CurrentButtonPressed);
                    Destroy(GameObject.FindGameObjectWithTag("DestroyItem"));
                }
            }
                
    }
    public static bool LevelComplete()
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
}
