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
            Vector3 velocity = tankRigidbody.linearVelocity;
            Vector3 forward = tankRigidbody.transform.forward;

            float forwardSpeed = Vector3.Dot(velocity, forward);

            speedText.text = "Speed: " + Mathf.Abs(Mathf.Round(forwardSpeed)*3.6f).ToString() + " km/h";
        }
    }
}
