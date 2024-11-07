using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int baseDamage = 20;

    void OnCollisionEnter(Collision collision)
    {
        int randomDamage = Mathf.RoundToInt(baseDamage * UnityEngine.Random.Range(0.75f, 1.25f));

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit " + collision.gameObject.name);
        }
        TankHealth targetHealth = collision.gameObject.GetComponent<TankHealth>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(randomDamage);
        }
        Destroy(gameObject);
    }
}
