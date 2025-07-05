using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (move != 0)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x = Mathf.Abs(currentScale.x) * Mathf.Sign(move);
            transform.localScale = currentScale;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        UpdateAnimator(move);
    }

    void UpdateAnimator(float move)
    {
        bool isJumping = !isGrounded;
        bool isRunning = move != 0 && isGrounded;
        bool isIdle = move == 0 && isGrounded;

        animator.SetBool("Jumping", isJumping);
        animator.SetBool("Running", isRunning); 
        animator.SetBool("Idle", isIdle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
