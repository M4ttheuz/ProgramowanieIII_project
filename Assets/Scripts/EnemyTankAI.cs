using UnityEngine;

public class EnemyTankAI : MonoBehaviour
{
    public Transform player;
    public Transform turret;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip shootSound;
    private AudioSource audioSource;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float fireRate = 2f;
    public float reloadTime = 2f;

    private float nextFireTime = 0f;
    private bool isReloading = false;

    public GameController gameController;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (gameController != null)
        {
            GameData currentData = SaveManager.Instance.LoadGame();
            currentData.playedBattles++;
            SaveManager.Instance.SaveGame(currentData);
        }
    }

    private void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
            RotateTurretTowardsPlayer();

            if (!isReloading && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
            else if (!isReloading)
            {
                StartCoroutine(Reload());
            }
        }
    }

    private void OnDestroy()
    {
        if (gameController != null)
        {
            gameController.TankDestroyed();
        }

        if (SaveManager.Instance != null)
        {
            GameData currentData = SaveManager.Instance.LoadGame();
            currentData.tanksDestroyed++;
            SaveManager.Instance.SaveGame(currentData);
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;

        transform.position += moveSpeed * Time.deltaTime * direction;

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
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().isPlayerBullet = false;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * 20f;

        Destroy(bullet, 3f);
    }

    System.Collections.IEnumerator Reload()
    {
        isReloading = true;
        float elapsedTime = 0f;
        while (elapsedTime < reloadTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isReloading = false;
    }
}
