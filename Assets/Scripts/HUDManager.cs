using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI speedText;
    public TankHealth tankHealth;
    public Rigidbody tankRigidbody;

    void Update()
    {
        if (healthText != null && tankHealth != null)
        {
            healthText.text = "HP: " + tankHealth.GetCurrentHealth().ToString();
        }

        if (speedText != null && tankRigidbody != null)
        {
            float speed = tankRigidbody.linearVelocity.magnitude;
            speedText.text = "Speed: " + Mathf.Round(speed).ToString() + " m/s";
        }
    }
}
