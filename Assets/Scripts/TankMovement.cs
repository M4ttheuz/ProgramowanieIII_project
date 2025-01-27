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

    public AudioClip tracksSound;
    private AudioSource audioSource;
    private AudioSource tracksAudioSource;
    private bool isMoving = false;

    private void Start()
    {
        tracksAudioSource = GetComponent<AudioSource>();

        if (tracksSound != null)
        {
            tracksAudioSource.clip = tracksSound;
            tracksAudioSource.loop = true;
            tracksAudioSource.volume = 0.3f;
        }
    }

    private void FixedUpdate()
    {
        Move();
        LimitSpeed();
        Steer();
        RotateTank();
        AdjustAudioVolume();
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
        float speed = forward * motorForce;

        isMoving = Mathf.Abs(forward) > 0f;

        foreach (WheelCollider wheel in driveWheels)
        {
            wheel.motorTorque = speed;
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

    private void AdjustAudioVolume()
    {
        if (isMoving && !tracksAudioSource.isPlaying)
        {
            tracksAudioSource.Play();
        }
        else if (!isMoving && tracksAudioSource.isPlaying)
        {
            tracksAudioSource.Stop();
        }
    }
}
