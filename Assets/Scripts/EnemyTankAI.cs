using UnityEngine;

public class EnemyTankAI : MonoBehaviour
{
    public Transform player;
    public Transform turret;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float fireRate = 2f; 

    private float nextFireTime = 0f;

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
            RotateTurretTowardsPlayer();

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;

        transform.position += direction * moveSpeed * Time.deltaTime;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void RotateTurretTowardsPlayer()
    {

        Vector3 directionToPlayer = player.position - turret.position;
        directionToPlayer.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        turret.rotation = Quaternion.Slerp(turret.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * 20f;

        Destroy(bullet, 3f);
    }
}
