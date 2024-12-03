using UnityEngine;

public class TankTurretAndGunControl : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform turret;
    public Transform gun;
    public Transform tankBody;
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
        Vector3 localDirection = tankBody.InverseTransformDirection(cameraTransform.forward);
        localDirection.y = 0;

        Vector3 worldDirection = tankBody.TransformDirection(localDirection);
        Quaternion targetRotation = Quaternion.LookRotation(worldDirection, Vector3.up);

        turret.rotation = Quaternion.RotateTowards(turret.rotation, targetRotation, turretRotationSpeed * Time.deltaTime);
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
