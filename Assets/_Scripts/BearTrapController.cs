using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Get reference to the Animator component
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (HealthTracker.instance != null)
            {
                HealthTracker.instance.decrementHearts();
            }

            if (animator != null)
            {
                animator.SetTrigger("PlayerCollision");
            }
        }
    }
}