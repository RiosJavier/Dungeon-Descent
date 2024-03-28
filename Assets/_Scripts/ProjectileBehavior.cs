using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 5f; // Speed of the projectile
    public Vector2 direction = Vector2.up; // Initial direction of the projectile
    public LayerMask whatStopsMovement;
    public Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is in the specified collision layer
        if (whatStopsMovement == (whatStopsMovement | (1 << other.gameObject.layer)))
        {
            // Destroy the projectile if it collides with an object in the specified layer
            Destroy(gameObject);
        }
    }
}
