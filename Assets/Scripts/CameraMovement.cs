using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tank;
    public Transform turret;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private TankHealth tankHealth;

    void Start()
    {
        tankHealth = tank.GetComponent<TankHealth>();

        transform.position = tank.position + offset;
    }

    void LateUpdate()
    {
        if (tankHealth != null)
        {
            Vector3 desiredPosition = tank.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(turret.position);
        }
    }
}
