using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    private float speed = 3f;
    private float jumpPower = 10f;
    public bool facingRight = false;

    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheckLeft;
    [SerializeField] private Transform wallCheckRight;
    [SerializeField] private LayerMask Ground;

    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //InvokeRepeating("Jump", 1f, jumpInterval);
        // Tidak perlu invokerepeating karena diurusin StateMachine
    }
    // Update is called once per frame
    void Update()
    {
        Flip();
        //Debug.Log("Grounded? " + isGrounded());
        animator.SetBool("isGrounded", isGrounded());
        animator.SetFloat("verticalVelocity", rb.linearVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded())
        {
            float direction;
            if (facingRight)
            {
                direction = 1f;
            }
            else
            {
                direction = -1f;
            }
            rb.linearVelocity = new Vector2(direction * speed, jumpPower);
        }
    }

    private void Flip()
    {
        Vector2 direction;
        Transform check;

        if (facingRight)
        {
            direction = Vector2.right;
            check = wallCheckRight;
        }
        else
        {
            direction = Vector2.left;
            check = wallCheckLeft;
        }

        //if (check == wallCheckRight)
        //{
        //    Debug.Log("Checking RIGHT");
        //}
        //else
        //{
        //    Debug.Log("Checking LEFT");
        //}
        RaycastHit2D hitWall = Physics2D.Raycast(check.position, direction, 0.5f, Ground);

        if (hitWall.collider != null)
        {
            facingRight = !facingRight;

            GetComponent<SpriteRenderer>().flipX = facingRight;
        }
    }
    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, Ground);
    }
}
