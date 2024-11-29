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
<<<<<<< HEAD
=======
        // Wyświetlanie zdrowia
>>>>>>> 07d08464b3adf6fdf6dd632065f8c076e9b6558b
        if (healthText != null && tankHealth != null)
        {
            healthText.text = "HP: " + tankHealth.GetCurrentHealth().ToString();
        }

<<<<<<< HEAD
        if (speedText != null && tankRigidbody != null)
        {
            Vector3 velocity = tankRigidbody.linearVelocity;
            Vector3 forward = tankRigidbody.transform.forward;

            float forwardSpeed = Vector3.Dot(velocity, forward);

            speedText.text = "Speed: " + Mathf.Abs(Mathf.Round(forwardSpeed)*3.6f).ToString() + " km/h";
=======
        // Wyświetlanie prędkości
        if (speedText != null && tankRigidbody != null)
        {
            // Obliczanie prędkości w kierunku do przodu
            Vector3 velocity = tankRigidbody.linearVelocity; // Prędkość światowa
            Vector3 forward = tankRigidbody.transform.forward; // Kierunek przodu czołgu

            // Prędkość wzdłuż kierunku do przodu
            float forwardSpeed = Vector3.Dot(velocity, forward);

            speedText.text = "Speed: " + Mathf.Abs(Mathf.Round(forwardSpeed)).ToString() + " m/s";
>>>>>>> 07d08464b3adf6fdf6dd632065f8c076e9b6558b
        }
    }
}
