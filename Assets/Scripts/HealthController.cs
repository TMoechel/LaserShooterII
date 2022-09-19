using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShake;
    [SerializeField] ParticleSystem hitEffect;


    CameraShake cameraShake;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        // prüft ob damageDealer existiert (sonst Absturz wenn kein if vorhanden wäre!)
        if (damageDealer != null)
        {
            // Schaden zufügen
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            // DamageDealer Hit() aufrufen
            damageDealer.Hit();
            ShakeCamera();
        }
    }

    private void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
            cameraShake.Play();
    }

    private void TakeDamage(int damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}