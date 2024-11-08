using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      
    public float rotationSpeed = 100f; 

    void Update()
    {
        
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; 
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, move);

        transform.Rotate(0, rotation, 0);
    }
}

