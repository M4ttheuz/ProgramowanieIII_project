using UnityEngine;

public class EnemyTankAI : MonoBehaviour
{
    public Transform player;        // Transform gracza, którego czo³g przeciwnika bêdzie œledziæ
    public Transform turret;        // Transform wie¿y, która bêdzie obracaæ siê w stronê gracza
    public Transform firePoint;     // Punkt wystrza³u
    public GameObject bulletPrefab; // Prefab pocisku
    public float moveSpeed = 5f;    // Prêdkoœæ ruchu przeciwnika
    public float rotationSpeed = 2f; // Szybkoœæ obrotu czo³gu
    public float fireRate = 2f;     // Szybkoœæ strzelania (strza³y na sekundê)

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
        // Kierunek w stronê gracza
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Ignorujemy oœ Y, aby czo³g nie zmienia³ wysokoœci

        // Ruch czo³gu przeciwnika
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Obrót w stronê gracza
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
