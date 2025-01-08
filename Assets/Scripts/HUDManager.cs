using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text healthText;
    public Text speedText;
    public Text damageText;
    public TankHealth tankHealth;
    public Rigidbody tankRigidbody;
    void Update()
    {
        if (damageText != null && tankHealth != null)
            damageText.text = "DMG: " + PlayerStats.totalDamageDealt.ToString();

        if (healthText != null && tankHealth != null)
        {
            healthText.text = "HP: " + tankHealth.GetCurrentHealth().ToString();
        }

        if (speedText != null && tankRigidbody != null)
        {
            Vector3 velocity = tankRigidbody.linearVelocity;
            Vector3 forward = tankRigidbody.transform.forward;

            float forwardSpeed = Vector3.Dot(velocity, forward);

            speedText.text = "Speed: " + Mathf.Abs(Mathf.Round(forwardSpeed * 3.6f)).ToString() + " km/h";
        }
    }
}
