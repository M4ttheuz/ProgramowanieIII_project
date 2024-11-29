using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Camera mainCamera;
    public Transform aimPosition;
    public float aimFOV = 30f;
    public float normalFOV = 60f;
    public float transitionSpeed = 5f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = mainCamera.transform.position;
        originalRotation = mainCamera.transform.rotation;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, aimPosition.position, Time.deltaTime * transitionSpeed);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, aimPosition.rotation, Time.deltaTime * transitionSpeed);
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, aimFOV, Time.deltaTime * transitionSpeed);
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, originalPosition, Time.deltaTime * transitionSpeed);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, originalRotation, Time.deltaTime * transitionSpeed);
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, normalFOV, Time.deltaTime * transitionSpeed);
        }
    }
}
