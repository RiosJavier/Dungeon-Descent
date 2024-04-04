using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
