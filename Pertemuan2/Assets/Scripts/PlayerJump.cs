using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded;
    public int totalJump;
    private Rigidbody rb;
    [HideInInspector] public int currentTotalJump = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            currentTotalJump++;
            if (currentTotalJump >= totalJump)
            {
                isGrounded = false;
            }
        }
    }
}
