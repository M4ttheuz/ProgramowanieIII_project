using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public WheelCollider[] driveWheels;
    public float motorForce = 150f;
    public float steerTorque = 15f;
    public float brakeForce = 300f;
    public float rotationSpeed = 100f;
    public float maxSpeed = 50f;

    public Rigidbody tankRigidbody;

    private void FixedUpdate()
    {
        Move();
        LimitSpeed();
        Steer();
        RotateTank();
    }

    private void LimitSpeed()
    {
        if (tankRigidbody.linearVelocity.magnitude > maxSpeed)
        {
            tankRigidbody.linearVelocity = tankRigidbody.linearVelocity.normalized * maxSpeed;
        }
    }

    private void Move()
    {
        float forward = Input.GetAxis("Vertical");

        foreach (WheelCollider wheel in driveWheels)
        {
            wheel.motorTorque = forward * motorForce;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            foreach (WheelCollider wheel in driveWheels)
            {
                wheel.brakeTorque = brakeForce;
            }
        }
        else
        {
            foreach (WheelCollider wheel in driveWheels)
            {
                wheel.brakeTorque = 0f;
            }
        }
    }

    private void Steer()
    {
        float turn = Input.GetAxis("Horizontal");

        foreach (WheelCollider wheel in driveWheels)
        {
            if (wheel != driveWheels[0]) 
                continue;
            wheel.steerAngle = turn * steerTorque;
        }
    }

    private void RotateTank()
    {
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0f, turn * rotationSpeed * Time.deltaTime, 0f);
    }
}
