using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    [HideInInspector] public Vector2 moveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(Horizontal, 0f).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * moveSpeed, ForceMode2D.Impulse);
    }
}
