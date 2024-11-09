using UnityEngine;

public class TankShooting : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject bulletPrefab;
    public Transform firePoint;     
=======
    public GameObject bulletPrefab; 
    public Transform firePoint;    
>>>>>>> a2820926e9b0e32811f17aa4d175a3c38f1fffa7
    public float bulletSpeed = 20f; 
    public float fireRate = 1f;     

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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;

        Destroy(bullet, 3f);
    }
}

