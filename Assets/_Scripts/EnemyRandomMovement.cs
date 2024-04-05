using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float changeDirectionInterval = 2f;
    public LayerMask wallLayer;
    public float tileSize = 1f; // Size of each tile

    private float nextDirectionChangeTime;
    private Vector2 currentDirection;
    private bool isMoving;

    private void Start()
    {
        nextDirectionChangeTime = Time.time + Random.Range(0f, changeDirectionInterval);
        ChooseRandomDirection();
    }

    private void Update()
    {
        if (!isMoving)
        {
            isMoving = true;
            Invoke("MoveEnemyOneTile", moveSpeed);
        }

        if (Time.time >= nextDirectionChangeTime)
        {
            ChooseRandomDirection();
            nextDirectionChangeTime = Time.time + Random.Range(0f, changeDirectionInterval);
        }
    }

    private void MoveEnemyOneTile()
    {
        Vector2 newPosition = (Vector2)transform.position + currentDirection * tileSize;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, currentDirection, tileSize, wallLayer);
        
        if (hit.collider == null) // If there's no wall in the way, move to the new position
        {
            transform.position = newPosition;
        }
        else // If there's a wall, choose a new direction
        {
            ChooseRandomDirection();
        }
        
        isMoving = false;
    }

    private void ChooseRandomDirection()
    {
        float randomValue = Random.value; // Generate a random value between 0 and 1
        if (randomValue < 0.25f) // Move up
        {
            currentDirection = Vector2.up;
        }
        else if (randomValue < 0.5f) // Move down
        {
            currentDirection = Vector2.down;
        }
        else if (randomValue < 0.75f) // Move left
        {
            currentDirection = Vector2.left;
        }
        else // Move right
        {
            currentDirection = Vector2.right;
        }
    }
}
