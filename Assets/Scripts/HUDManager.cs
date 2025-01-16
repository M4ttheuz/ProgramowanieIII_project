using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text healthText;
    public Text speedText;
    public Text damageText;
    public PlayerHealth playerHealth;
    public Rigidbody playerRigidbody;

    void Update()
    {
        if (damageText != null && playerHealth != null)
        {
            damageText.text = "DMG: " + PlayerStats.totalDamageDealt.ToString();
        }

        if (healthText != null && playerHealth != null)
        {
            healthText.text = "HP: " + playerHealth.GetCurrentHealth().ToString();
        }

        if (speedText != null && playerRigidbody != null)
        {
            Vector3 velocity = playerRigidbody.linearVelocity;
            Vector3 forward = playerRigidbody.transform.forward;

            float forwardSpeed = Vector3.Dot(velocity, forward);

            speedText.text = "Speed: " + Mathf.Abs(Mathf.Round(forwardSpeed * 3.6f)).ToString() + " km/h";
        }
    }
}
