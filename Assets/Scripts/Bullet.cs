using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int baseDamage = 20;
    public bool isPlayerBullet;

    void OnCollisionEnter(Collision collision)
    {
        int randomDamage = Mathf.RoundToInt(baseDamage * UnityEngine.Random.Range(0.75f, 1.25f));

        TankHealth targetHealth = collision.gameObject.GetComponent<TankHealth>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(randomDamage);

            if (isPlayerBullet)
            {
                PlayerStats.totalDamageDealt += randomDamage;
            }
        }

        Destroy(gameObject);
    }
}
