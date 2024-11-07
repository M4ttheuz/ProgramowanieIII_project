using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tank;
    public Transform turret;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private bool isTankAlive = true;

    private TankHealth tankHealth;

    void Start()
    {
        tankHealth = tank.GetComponent<TankHealth>();

        transform.position = tank.position + offset;
    }

    void LateUpdate()
    {
        if (tankHealth != null && tankHealth.currentHealth > 0)
        {
            isTankAlive = true;
        }
        else
        {
            isTankAlive = false;
        }
        
        if (isTankAlive)
        {
            Vector3 desiredPosition = tank.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(turret.position);
        }
    }
}
