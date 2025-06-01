using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float health {get;set;}
    public float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    //void Update()
    //{
    //    if (health <= 0) Destroy(gameObject);
    //}
    // StateMachine mengurus death enemynya

}
