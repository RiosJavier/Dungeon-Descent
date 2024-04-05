using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapController : MonoBehaviour
{
    private Animator animator;
    private bool trapTriggered = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !trapTriggered)
        {
            trapTriggered = true;

            if (HealthTracker.instance != null)
            {
                HealthTracker.instance.decrementHearts();
                HealthTracker.instance.decrementHearts();
            }

            if (animator != null)
            {
                animator.SetTrigger("PlayerCollision");
            }
        }
    }
}