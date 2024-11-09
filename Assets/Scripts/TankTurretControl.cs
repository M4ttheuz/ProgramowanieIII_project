using UnityEngine;

public class TankTurretControl : MonoBehaviour
{
    public Transform turret;          
    public Transform barrel;           
    public float rotationSpeed = 100f;
    public float elevationSpeed = 50f; 

    public float maxElevation = 20f;  
    public float maxDepression = -10f;

    void Update()
    {
        RotateTurret();
        ElevateBarrel();
    }

    void RotateTurret()
    {
        float mouseX = Input.GetAxis("Mouse X");

        turret.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
    }

    void ElevateBarrel()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float newElevation = barrel.localEulerAngles.x - mouseY * elevationSpeed * Time.deltaTime;

        if (newElevation > 180) newElevation -= 360;
        newElevation = Mathf.Clamp(newElevation, maxDepression, maxElevation);

        barrel.localEulerAngles = new Vector3(newElevation, barrel.localEulerAngles.y, barrel.localEulerAngles.z);
    }
}
