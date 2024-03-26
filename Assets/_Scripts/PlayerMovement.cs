using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int last;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {   
        if ((Input.GetKey("w") || Input.GetKey("up")) && (Input.GetKey("a") || Input.GetKey("left")) == false && (Input.GetKey("d") || Input.GetKey("right")) == false)
        {
            last = 1;
        }
        else if ((Input.GetKey("s") || Input.GetKey("down")) && (Input.GetKey("a") || Input.GetKey("left")) == false && (Input.GetKey("d") || Input.GetKey("right")) == false)
        {
            last = 2;
        }
        else if ((Input.GetKey("a") || Input.GetKey("left")) && (Input.GetKey("w") || Input.GetKey("up")) == false && (Input.GetKey("s") || Input.GetKey("down")) == false)
        {
            last = 3;
        }
        else if ((Input.GetKey("d") || Input.GetKey("right")) && (Input.GetKey("w") || Input.GetKey("up")) == false && (Input.GetKey("s") || Input.GetKey("down")) == false)
        {
            last = 4;
        }
        else if((Input.GetKey("d") || Input.GetKey("right")) == false && (Input.GetKey("w") || Input.GetKey("up")) == false && (Input.GetKey("s") || Input.GetKey("down")) == false && (Input.GetKey("a")|| Input.GetKey("left")) == false)
        {    
            last = 5;
        }

        if (last == 1)
        {
            rb.velocity = new Vector2(0, 1 * moveSpeed);
        }
        else if (last == 2)
        {
            rb.velocity = new Vector2(0, -1 * moveSpeed);
        } else if (last == 3)
        {
            rb.velocity = new Vector2(-1 * moveSpeed, 0);
        }
        else if (last == 4)
        {
            rb.velocity = new Vector2(1 * moveSpeed, 0);
        }
        else if (last == 5)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
