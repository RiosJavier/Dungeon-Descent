using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthPotion : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }

        //HealthTracker healthTracker = GetComponent<HealthTracker>();

        if(HealthTracker.instance != null)
        {
            HealthTracker.instance.addHealth();
        }

    }
}
