using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapController : MonoBehaviour
{
    // Start is called before the first frame update
    public class CollisionAnimator : MonoBehaviour
    {
        public Animator animator;
        public AnimationClip defaultAnimation;

        void Start()
        {
            animator.Play(defaultAnimation.name, 0, 0);
            animator.speed = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if the collision is happening with the object you want
            if (collision.tag == "Player")
            {
                // Trigger the animation
                animator.SetTrigger("CollisionBearTrap");
            }
        }
    }
}
