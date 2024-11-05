using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab pocisku
    public Transform firePoint;     // Punkt, z kt�rego pocisk jest wystrzeliwany
    public float bulletSpeed = 20f; // Pr�dko�� pocisku
    public float fireRate = 1f;     // Szybko�� strzelania (pociski na sekund�)

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Tworzenie pocisku
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Nadanie pociskowi pr�dko�ci
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;

        // Opcjonalnie: dodanie czasu �ycia pocisku
        Destroy(bullet, 3f); // Zniszczenie pocisku po 3 sekundach
    }
}

