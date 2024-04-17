using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public Vector3 directionFacing = Vector3.zero;
    public bool isJumping = false;
    private bool canJumpAgain = false; 

    Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f));
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                Move(new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(Jump());
        }
    }

    private void Move(Vector3 direction)
    {
        if (!Physics2D.OverlapCircle(movePoint.position + direction, .2f, whatStopsMovement))
        {
            movePoint.position += direction;
            directionFacing = direction;

            
            if (animator != null)
            {
                animator.SetFloat("DirectionX", direction.x);
                animator.SetFloat("DirectionY", direction.y);
            }
        }
    }

    private IEnumerator Jump()
    {
        isJumping = true;

        Vector3 jumpDestination = movePoint.position + 2 * directionFacing;

        RaycastHit2D hit = Physics2D.Raycast(movePoint.position, directionFacing, 1f, whatStopsMovement);
        if (hit.collider == null)
        {
            float scaleDuration = 0.1f;
            Vector3 originalScale = transform.localScale;
            Vector3 targetScale = originalScale * 1.3f;

            float elapsedTime = 0f;
            while (elapsedTime < scaleDuration)
            {
                transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / scaleDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = targetScale;
            movePoint.position = jumpDestination;

            elapsedTime = 0f;
            while (elapsedTime < scaleDuration)
            {
                transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsedTime / scaleDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = originalScale;
        }

        isJumping = false;
    }
}
