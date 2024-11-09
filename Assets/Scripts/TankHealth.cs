using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject healthBarPrefab;
    private Slider healthSlider;

    public GameObject GameOverText;

    public int GetCurrentHealth()
    {
        return currentHealth;
    }


    void Start()
    {
        currentHealth = maxHealth;

        GameObject healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 2, Quaternion.identity, transform);
        healthSlider = healthBarInstance.GetComponent<Slider>();

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        if (GameOverText != null)
        {
            GameOverText.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
        if (GameOverText != null)
        {
            GameOverText.SetActive(true);
        }

        Time.timeScale = 0f;

        Debug.Log(gameObject.name + " zosta³ zniszczony!");

        Destroy(gameObject);
    }
}
