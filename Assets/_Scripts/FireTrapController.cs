using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapController : MonoBehaviour
{
    private Animator animator;
    private int fireStateHash;
    private bool isPlayerOnFire;
    private bool hasDamagedPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        fireStateHash = Animator.StringToHash("Base Layer.FireUp");
    }

    void Update()
    {
        // check if the player is on fire, the FireUp animation is playing, and the player hasn't been damaged yet
        if (isPlayerOnFire && IsFireUp() && !hasDamagedPlayer)
        {
            if (HealthTracker.instance != null)
            {
                HealthTracker.instance.decrementHearts();
                hasDamagedPlayer = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerOnFire = true;
            if (hasDamagedPlayer)
            {
                hasDamagedPlayer = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerOnFire = false;
            hasDamagedPlayer = false;
        }
    }

    private bool IsFireUp()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.fullPathHash == fireStateHash;
    }
}
