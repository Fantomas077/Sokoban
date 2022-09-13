using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
  public  float speed = 5f;

    

    public bool LookRight = false;
    public Animator animator;

    bool lookright = false;

    Vector2 movement;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
      movement.x=  Input.GetAxisRaw("Horizontal");
      movement.y= Input.GetAxisRaw("Vertical");

        if(movement.x>0 && lookright)
        {
            Flip();
        }

        else if(movement.x<0 && !lookright)
        {
            Flip();
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

   

    void Flip()
    {
        lookright = !lookright;
        Vector2 theScale = transform.lossyScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
