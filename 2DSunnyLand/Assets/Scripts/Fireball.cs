using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float horizontal;
    public float fireballSpeed;
    public float damage;
    public float graceDuration;
    private Rigidbody2D rb;
    private bool facingRight;
    //[SerializeField] private GameObject player;
    private PlayerMovement playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerMovement = FindObjectOfType<PlayerMovement>();
        facingRight = playerMovement.facingRight;
        
        if (facingRight)
        {
            rb.linearVelocity = Vector2.right * fireballSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.left * fireballSpeed;
        }
    }

    void Update()
    {
        graceDuration -= Time.deltaTime;
        if(graceDuration <= 0)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<IDamageable>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
