using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float x, y;
    public float sensitivity, distance;
    public Vector2 xminmax;
    public Transform target;
    private void LateUpdate()
    {
        x += Input.GetAxis("Mouse Y") * sensitivity * -1;
        y += Input.GetAxis("Mouse X") * sensitivity;

        x = Mathf.Clamp(x, xminmax.x, xminmax.y);

        transform.eulerAngles = new Vector3(x, y, 0);

        transform.position = target.position - transform.forward * distance;
    }
}
