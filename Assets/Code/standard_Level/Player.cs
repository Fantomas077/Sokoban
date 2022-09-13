using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public static int Steps;
    public TextMeshProUGUI Text;
    public bool Move(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }

        direction.Normalize(); // nur ein schritt kann gemacht werden 

        if (Blocked(transform.position, direction)) // checkt ob geblockt ist und fals ja soll nichts gemacht werden, fals nein soll gelaufen werden
        {
            Player.Steps += 0;
            Text.text = "Steps: " + Player.Steps;
            return false;
        }
        else
        {

            transform.Translate(direction);
            Player.Steps += 1;
            Text.text = "Steps: " + Player.Steps;
            return true;
        }
    }
     bool Blocked(Vector3 position, Vector2 direction)
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
                Box boxx = box.GetComponent<Box>();
                if (boxx && boxx.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
}
