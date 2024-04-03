using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (HealthTracker.instance != null)
            {
                HealthTracker.instance.decrementHearts();
            }
        }
    }
}
