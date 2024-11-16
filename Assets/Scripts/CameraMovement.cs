using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera playerCamera;
    public Transform tank;
    public Transform turret;
    public Transform firePoint;
    public float arcadeFOV = 60f;
    public float sniperFOV = 30f;
    public Vector3 arcadeOffset = new Vector3(0, 5, -10);
    public float rotationSpeed = 2f;

    private bool isSniperMode = false;
    private bool isAiming = false;

    void Start()
    {
        playerCamera.fieldOfView = arcadeFOV;
        playerCamera.transform.position = tank.position + arcadeOffset;
    }

    void Update()
    {
        HandleInput();
        FollowTank();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SwitchToSniperMode();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SwitchToArcadeMode();
        }

        if (!isSniperMode && Input.GetMouseButtonDown(1))
        {
            isAiming = true;
        }

        if (!isSniperMode && Input.GetMouseButtonUp(1))
        {
            isAiming = false;
        }

        if (isAiming && !isSniperMode)
        {
            RotateTurret();
        }
    }

    void SwitchToSniperMode()
    {
        isSniperMode = true;
        playerCamera.fieldOfView = sniperFOV;
    }

    void SwitchToArcadeMode()
    {
        isSniperMode = false;
        playerCamera.fieldOfView = arcadeFOV;
    }

    void RotateTurret()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        turret.Rotate(Vector3.up * horizontalInput * rotationSpeed, Space.World);
        playerCamera.transform.Rotate(Vector3.left * verticalInput * rotationSpeed);
    }

    void FollowTank()
    {
        if (isSniperMode)
        {
            playerCamera.transform.position = firePoint.position;
            playerCamera.transform.rotation = firePoint.rotation; // Kamera patrzy dok³adnie przez firePoint
        }
        else
        {
            playerCamera.transform.position = tank.position + arcadeOffset;
            playerCamera.transform.LookAt(turret);
        }
    }
}
