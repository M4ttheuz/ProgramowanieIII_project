using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit " + collision.gameObject.name);
        }

        Destroy(gameObject);
    }
}
