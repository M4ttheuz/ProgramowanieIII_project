using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Prêdkoœæ ruchu czo³gu do przodu
    public float rotationSpeed = 100f;  // Prêdkoœæ obrotu czo³gu

    void Update()
    {
        // Pobieranie wejœcia (Input) z klawiatury
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Ruch przód-ty³
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // Obrót

        // Ruch czo³gu do przodu i do ty³u
        transform.Translate(0, 0, move);

        // Obrót czo³gu wokó³ osi Y
        transform.Rotate(0, rotation, 0);
    }
}

