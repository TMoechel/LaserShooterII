using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] int health = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        // prüft ob damageDealer existiert (sonst Absturz wenn kein if vorhanden wäre!)
        if (damageDealer != null)
        {
            // Schaden zufügen
            TakeDamage(damageDealer.GetDamage());
            // DamageDealer Hit() aufrufen
            damageDealer.Hit();
        }

    }

    private void TakeDamage(int damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}