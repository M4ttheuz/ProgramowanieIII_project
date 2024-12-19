using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 50f, 0f);

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position + offset;
            newPosition.y = offset.y;
            transform.position = newPosition;
        }
    }
}
