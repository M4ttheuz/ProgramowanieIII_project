using UnityEngine;

public class TankTurretControl : MonoBehaviour
{
    public Transform turret;           // Referencja do obiektu wie�yczki
    public Transform barrel;           // Referencja do obiektu lufy
    public float rotationSpeed = 100f; // Pr�dko�� obrotu wie�yczki w poziomie
    public float elevationSpeed = 50f; // Pr�dko�� obrotu lufy w pionie

    public float maxElevation = 20f;   // Maksymalny k�t podniesienia lufy
    public float maxDepression = -10f; // Minimalny k�t opuszczenia lufy

    void Update()
    {
        RotateTurret();
        ElevateBarrel();
    }

    void RotateTurret()
    {
        // Pobranie ruchu myszy w poziomie
        float mouseX = Input.GetAxis("Mouse X");

        // Obr�t wie�yczki w osi Y w oparciu o ruch myszy i pr�dko�� obrotu
        turret.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
    }

    void ElevateBarrel()
    {
        // Pobranie ruchu myszy w pionie
        float mouseY = Input.GetAxis("Mouse Y");

        // Obliczenie nowego k�ta podniesienia/opuszczenia lufy
        float newElevation = barrel.localEulerAngles.x - mouseY * elevationSpeed * Time.deltaTime;

        // Przekszta�cenie k�ta, by ograniczy� obr�t mi�dzy maxDepression a maxElevation
        if (newElevation > 180) newElevation -= 360;
        newElevation = Mathf.Clamp(newElevation, maxDepression, maxElevation);

        // Ustawienie k�ta podniesienia lufy
        barrel.localEulerAngles = new Vector3(newElevation, barrel.localEulerAngles.y, barrel.localEulerAngles.z);
    }
}
