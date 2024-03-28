using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 5f; // Speed of the projectile
    public Vector2 direction = Vector2.up; // Initial direction of the projectile
    public LayerMask whatStopsMovement;
    public Transform movePoint;

    // Update is called once per frame
    void Update()
    {
        // Move the projectile in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Function to set the direction of the projectile
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized; // Normalize the direction vector
    }

    // Function to handle collisions with other objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Log the layer of the collided object for debugging
        Debug.Log("Collided object layer: " + LayerMask.LayerToName(collision.gameObject.layer));

        if (LayerMask.LayerToName(collision.gameObject.layer) == "WALL")
        {
            Debug.Log("COLLISIONS");
            Destroy(gameObject);
        }
    }
}
