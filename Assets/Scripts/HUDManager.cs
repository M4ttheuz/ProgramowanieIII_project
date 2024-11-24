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
        // Wyświetlanie zdrowia
        if (healthText != null && tankHealth != null)
        {
            healthText.text = "HP: " + tankHealth.GetCurrentHealth().ToString();
        }

        // Wyświetlanie prędkości
        if (speedText != null && tankRigidbody != null)
        {
            // Obliczanie prędkości w kierunku do przodu
            Vector3 velocity = tankRigidbody.linearVelocity; // Prędkość światowa
            Vector3 forward = tankRigidbody.transform.forward; // Kierunek przodu czołgu

            // Prędkość wzdłuż kierunku do przodu
            float forwardSpeed = Vector3.Dot(velocity, forward);

            speedText.text = "Speed: " + Mathf.Abs(Mathf.Round(forwardSpeed)).ToString() + " m/s";
        }
    }
}
