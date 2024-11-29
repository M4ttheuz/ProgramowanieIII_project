using UnityEngine;

public class TankTurretAndGunControl : MonoBehaviour
{
<<<<<<< HEAD
    public Camera camera;
=======
>>>>>>> 07d08464b3adf6fdf6dd632065f8c076e9b6558b
    public Transform turret;
    public Transform gun;
    public float turretRotationSpeed = 100f;
    public float gunElevationSpeed = 50f;
    public float maxGunElevation = 20f;
    public float minGunElevation = -10f;

<<<<<<< HEAD
    void Update()
=======
    private void Update()
>>>>>>> 07d08464b3adf6fdf6dd632065f8c076e9b6558b
    {
        RotateTurret();
        ElevateGun();
    }

<<<<<<< HEAD
    void RotateTurret()
    {
        Vector3 direction = camera. - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        Vector3 eulers = rotation.eulerAngles;

        turret.Rotate(turret.up, eulers.y);
    }

    void ElevateGun()
=======
    private void RotateTurret()
    {
        float turretRotation = Input.GetAxis("Mouse X") * turretRotationSpeed * Time.deltaTime;
        turret.Rotate(0f, turretRotation, 0f);
    }

    private void ElevateGun()
>>>>>>> 07d08464b3adf6fdf6dd632065f8c076e9b6558b
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float newElevation = gun.localEulerAngles.x - mouseY * gunElevationSpeed * Time.deltaTime;

        if (newElevation > 180)
            newElevation -= 360;

        newElevation = Mathf.Clamp(newElevation, minGunElevation, maxGunElevation);
        gun.localEulerAngles = new Vector3(newElevation, gun.localEulerAngles.y, gun.localEulerAngles.z);
    }
}
