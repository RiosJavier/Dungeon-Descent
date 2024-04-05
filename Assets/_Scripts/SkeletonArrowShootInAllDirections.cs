using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArrowShootInAllDirections : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab of the arrow to shoot
    public Transform arrowSpawnPoint; // Point where arrows will spawn
    public float minInterval = 1f; // Minimum interval between shots
    public float maxInterval = 3f; // Maximum interval between shots
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRandomArrow());
    }

    IEnumerator ShootRandomArrow()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

            // Randomly choose a direction to shoot
            int direction = Random.Range(0, 4); // 0: up, 1: down, 2: left, 3: right

            // Instantiate the arrow prefab at the spawn point
            GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
            ProjectileBehavior projectile = arrow.GetComponent<ProjectileBehavior>();

            switch (direction)
            {
                case 0:
                    projectile.SetDirection(Vector2.up);
                    break;
                case 1:
                    projectile.SetDirection(Vector2.down);
                    break;
                case 2:
                    projectile.SetDirection(Vector2.left);
                    break;
                case 3:
                    projectile.SetDirection(Vector2.right);
                    break;
            }
        }
    }
}
