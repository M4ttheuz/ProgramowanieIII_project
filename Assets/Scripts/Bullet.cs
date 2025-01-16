using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int baseDamage = 20;
    public bool isPlayerBullet;

    void OnCollisionEnter(Collision collision)
    {
        int randomDamage = Mathf.RoundToInt(baseDamage * UnityEngine.Random.Range(0.75f, 1.25f));

        if (isPlayerBullet)
        {
            EnemyHealth targetHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(randomDamage);
                PlayerStats.totalDamageDealt += randomDamage;
            }
        }
        else
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(randomDamage);
            }
        }

        Destroy(gameObject);
    }
}
