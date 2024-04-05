using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
    private Animator animator;
    private int spikeStateHash;
    private bool isPlayerOnSpike;
    private bool hasDamagedPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spikeStateHash = Animator.StringToHash("Base Layer.SpikeUp");
    }

    void Update()
    {
        // check if the player is on spike, the SpikeUp animation is playing, and the player hasn't been damaged yet
        if (isPlayerOnSpike && IsSpikeUp() && !hasDamagedPlayer)
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
            isPlayerOnSpike = true;
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
            isPlayerOnSpike = false;
            hasDamagedPlayer = false;
        }
    }

    private bool IsSpikeUp()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.fullPathHash == spikeStateHash;
    }
}
