using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int totalDamageDealt = 0;

    public GameObject healthBarPrefab;
    private Slider healthSlider;

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetCurrentDamage()
    {
        return totalDamageDealt;
    }


    void Start()
    {
        currentHealth = maxHealth;

        GameObject healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 5, Quaternion.identity, transform);
        healthSlider = healthBarInstance.GetComponent<Slider>();

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        totalDamageDealt += damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " zosta³ zniszczony!");
        Destroy(gameObject);
    }
}
