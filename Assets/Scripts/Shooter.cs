using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileLifetime = 15;
    [SerializeField] float firingRate = 0.2f;


    public bool isFiring;
    private Coroutine firingCoroutine;

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject laserShot = Instantiate(projectilePrefab,
                transform.position, Quaternion.identity);

            Rigidbody2D rbLaserShot = laserShot.GetComponent<Rigidbody2D>();
            if (rbLaserShot != null)
            {
                // up is the velocity in the direction of the green arrow value is 1
                rbLaserShot.velocity = transform.up * projectileSpeed;
            }

            Destroy(laserShot, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
