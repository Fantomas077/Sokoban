using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 positionmouse;
    
    private void Update()
    {
        positionmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(positionmouse.x), Mathf.Round(positionmouse.y));
    }
}
