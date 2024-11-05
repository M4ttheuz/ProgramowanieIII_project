using UnityEngine;

public class EnemyTankAI : MonoBehaviour
{
    public Transform player;        // Transform gracza, kt�rego czo�g przeciwnika b�dzie �ledzi�
    public Transform turret;        // Transform wie�y, kt�ra b�dzie obraca� si� w stron� gracza
    public Transform firePoint;     // Punkt wystrza�u
    public GameObject bulletPrefab; // Prefab pocisku
    public float moveSpeed = 5f;    // Pr�dko�� ruchu przeciwnika
    public float rotationSpeed = 2f; // Szybko�� obrotu czo�gu
    public float fireRate = 2f;     // Szybko�� strzelania (strza�y na sekund�)

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
        // Kierunek w stron� gracza
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Ignorujemy o� Y, aby czo�g nie zmienia� wysoko�ci

        // Ruch czo�gu przeciwnika
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Obr�t w stron� gracza
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
