using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : Player
{
    public float moveSpeed;
    private Camera cam;
    private Rigidbody rb;
    [HideInInspector] public Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.GetComponent<Camera>();
    }

    private void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(Horizontal, 0f, Vertical).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Impulse);
    }
}
