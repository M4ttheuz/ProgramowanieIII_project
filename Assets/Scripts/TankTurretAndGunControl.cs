using UnityEngine;

public class TankTurretAndGunControl : MonoBehaviour
{
    public Camera camera;
    public Transform turret;
    public Transform gun;
    public float turretRotationSpeed = 100f;
    public float gunElevationSpeed = 50f;
    public float maxGunElevation = 20f;
    public float minGunElevation = -10f;

    void Update()
    {
        RotateTurret();
        ElevateGun();
    }

    void RotateTurret()
    {
        Vector3 direction = camera. - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        Vector3 eulers = rotation.eulerAngles;

        turret.Rotate(turret.up, eulers.y);
    }

    void ElevateGun()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float newElevation = gun.localEulerAngles.x - mouseY * gunElevationSpeed * Time.deltaTime;

        if (newElevation > 180)
            newElevation -= 360;

        newElevation = Mathf.Clamp(newElevation, minGunElevation, maxGunElevation);
        gun.localEulerAngles = new Vector3(newElevation, gun.localEulerAngles.y, gun.localEulerAngles.z);
    }
}
