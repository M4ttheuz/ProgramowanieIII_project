using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float sensitivity = 5f;
    public Vector2 xminmax;
    public LayerMask collisionMask;
    public float collisionOffset = 0.2f;

    private float x, y;

    void Update()
    {
        x += Input.GetAxis("Mouse Y") * sensitivity * -1;
        y += Input.GetAxis("Mouse X") * sensitivity;

        x = Mathf.Clamp(x, xminmax.x, xminmax.y);

        Vector3 desiredPosition = target.position - transform.forward * distance;

        if (Physics.Linecast(target.position, desiredPosition, out RaycastHit hit, collisionMask))
        {
            float hitDistance = Vector3.Distance(target.position, hit.point) - collisionOffset;
            transform.position = target.position - transform.forward * hitDistance;
        }
        else
        {
            transform.position = desiredPosition;
        }

        transform.rotation = Quaternion.Euler(x, y, 0);
    }
}
