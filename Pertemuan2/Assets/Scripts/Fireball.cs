using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed;
    public float damage;
    public float graceDuration;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        graceDuration -= Time.deltaTime;
        if(graceDuration <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(fireballSpeed, rb.position.y, fireballSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamageable>() == null)
        {
            return;
        }
        other.GetComponent<IDamageable>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
