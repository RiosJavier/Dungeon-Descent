using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{
    private bool playerJumpedOver = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                StartCoroutine(CheckPlayerJump(player));
            }
        }
    }

    private IEnumerator CheckPlayerJump(PlayerController player)
    {
        yield return new WaitForFixedUpdate();

        if (!playerJumpedOver && player.isJumping)
        {
            playerJumpedOver = true;
        }
        else if (!playerJumpedOver && !player.isJumping)
        {
            //Player falling into pit animation
            HealthTracker.instance.decrementHearts();
        }

        yield return new WaitForSeconds(0.2f);
        playerJumpedOver = false;
    }
}
