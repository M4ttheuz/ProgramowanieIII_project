using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tank; // Transform czo�gu, za kt�rym b�dzie pod��a� kamera
    public Transform turret; // Transform wie�y czo�gu
    public Vector3 offset; // Offset kamery wzgl�dem czo�gu
    public float smoothSpeed = 0.125f; // Pr�dko�� wyg�adzania ruchu kamery

    void Start()
    {
        // Ustawienie pocz�tkowej pozycji kamery z odpowiednim offsetem
        transform.position = tank.position + offset;
    }

    void LateUpdate()
    {
        // Obliczamy docelow� pozycj� kamery
        Vector3 desiredPosition = tank.position + offset;
        // Wyg�adzamy ruch kamery
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Ustawiamy now� pozycj� kamery
        transform.position = smoothedPosition;

        // Ustawiamy kamer�, aby patrzy�a w kierunku wie�y
        transform.LookAt(turret.position); // Kamera patrzy w kierunku wie�y czo�gu
    }
}
