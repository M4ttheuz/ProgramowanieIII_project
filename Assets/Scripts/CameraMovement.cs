using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tank; // Transform czo³gu, za którym bêdzie pod¹¿aæ kamera
    public Transform turret; // Transform wie¿y czo³gu
    public Vector3 offset; // Offset kamery wzglêdem czo³gu
    public float smoothSpeed = 0.125f; // Prêdkoœæ wyg³adzania ruchu kamery

    void Start()
    {
        // Ustawienie pocz¹tkowej pozycji kamery z odpowiednim offsetem
        transform.position = tank.position + offset;
    }

    void LateUpdate()
    {
        // Obliczamy docelow¹ pozycjê kamery
        Vector3 desiredPosition = tank.position + offset;
        // Wyg³adzamy ruch kamery
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Ustawiamy now¹ pozycjê kamery
        transform.position = smoothedPosition;

        // Ustawiamy kamerê, aby patrzy³a w kierunku wie¿y
        transform.LookAt(turret.position); // Kamera patrzy w kierunku wie¿y czo³gu
    }
}
