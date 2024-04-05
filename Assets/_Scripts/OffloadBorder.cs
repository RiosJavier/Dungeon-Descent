using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffloadBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Offloader")
        {
            Destroy(transform.root.gameObject);
        }
        

        /*else
        {
            Destroy(collision.gameObject);
        }*/
    }
}
