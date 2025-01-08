using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Transform muzzle;
    public RectTransform crosshair;
    void Update()
    {
        if (muzzle != null && crosshair != null)
        {
            Vector3 targetPosition = muzzle.position + muzzle.forward * 10f;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetPosition);
            crosshair.position = screenPosition;
        }
    }
}
