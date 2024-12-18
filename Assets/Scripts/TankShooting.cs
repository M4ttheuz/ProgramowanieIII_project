using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 5f;
    public int maxAmmo = 30;
    private int currentAmmo;

    private float nextFireTime = 0f;
    private float reloadTimeRemaining = 0f;

    public Text ammoText;
    public Text reloadText;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoDisplay();
    }

    void Update()
    {
        reloadText.color = Color.green;
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime && currentAmmo > 0)
        {
            Shoot();
            currentAmmo--;
            nextFireTime = Time.time + fireRate;
            UpdateAmmoDisplay();
        }

        if (Time.time < nextFireTime)
        {
            reloadTimeRemaining = nextFireTime - Time.time;
            UpdateReloadDisplay();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;
        Destroy(bullet, 3f);
    }

    void UpdateAmmoDisplay()
    {
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo;
        }
    }

    void UpdateReloadDisplay()
    {
        if (reloadText != null)
        {
            reloadText.color = Color.red;
            reloadText.text = reloadTimeRemaining.ToString("F1") + "s";
        }
    }
}
