using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{
    private bool playerJumpedOver = false;
    private Vector3 originalScale;

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
            yield return new WaitForSeconds(.2f);
            ScaleDownPlayer(player);
            HealthTracker.instance.health = 0;
        }

        playerJumpedOver = false;
    }

    private void ScaleDownPlayer(PlayerController player)
    {
        float duration = 1f;
        Vector3 targetScale = new Vector3(0.5f, 0.5f, 1f);

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            player.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
        }

        player.transform.localScale = targetScale;
    }       
}
