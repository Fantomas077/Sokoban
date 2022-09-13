using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool OnCross;
   public bool Move(Vector2 direction)
    {
        if (Box_Blocked(transform.position,direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            SearchKross();
            return true;
        }

    }

    public bool Box_Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 position_new = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == position_new.x && wall.transform.position.y == position_new.y)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == position_new.x && box.transform.position.y == position_new.y)
            {
                    return true;
            }
        }
        return false;
    }

    public void SearchKross()
    {
        GameObject[] crosses = GameObject.FindGameObjectsWithTag("Cross");
        foreach (var cross in crosses)
        {
            if (transform.position.x == cross.transform.position.x && transform.position.y == cross.transform.position.y)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
                OnCross = true;
                return;
            }
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        OnCross = false;
    }
}


