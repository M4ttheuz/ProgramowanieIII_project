using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float sensitivity = 5f;
    public float distance = 10f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        pitch = Mathf.Clamp(pitch, -35f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = new Vector3(0f, 2f, -distance);

        transform.position = target.position + rotation * offset;
        transform.LookAt(target.position);
    }
}
