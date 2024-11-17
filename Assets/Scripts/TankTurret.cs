using UnityEngine;

public class TankTurret : MonoBehaviour
{
    public Transform turret;
    public float rotationSpeed = 5f;

    private void Update()
    {
        RotateTurret();
    }

    void RotateTurret()
    {
        Vector3 targetDirection = turret.position - Camera.main.transform.position;
        targetDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        turret.rotation = Quaternion.Slerp(turret.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
