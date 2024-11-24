using UnityEngine;

public class TankTurretAndGunControl : MonoBehaviour
{
    public Transform turret;
    public Transform gun;
    public float turretRotationSpeed = 100f;
    public float gunElevationSpeed = 50f;
    public float maxGunElevation = 20f;
    public float minGunElevation = -10f;

    private void Update()
    {
        RotateTurret();
        ElevateGun();
    }

    private void RotateTurret()
    {
        float turretRotation = Input.GetAxis("Mouse X") * turretRotationSpeed * Time.deltaTime;
        turret.Rotate(0f, turretRotation, 0f);
    }

    private void ElevateGun()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float newElevation = gun.localEulerAngles.x - mouseY * gunElevationSpeed * Time.deltaTime;

        if (newElevation > 180)
            newElevation -= 360;

        newElevation = Mathf.Clamp(newElevation, minGunElevation, maxGunElevation);
        gun.localEulerAngles = new Vector3(newElevation, gun.localEulerAngles.y, gun.localEulerAngles.z);
    }
}
