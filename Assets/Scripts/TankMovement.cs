using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Pr�dko�� ruchu czo�gu do przodu
    public float rotationSpeed = 100f;  // Pr�dko�� obrotu czo�gu

    void Update()
    {
        // Pobieranie wej�cia (Input) z klawiatury
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Ruch prz�d-ty�
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // Obr�t

        // Ruch czo�gu do przodu i do ty�u
        transform.Translate(0, 0, move);

        // Obr�t czo�gu wok� osi Y
        transform.Rotate(0, rotation, 0);
    }
}

