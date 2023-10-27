using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    // Called when the enemy is shot
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {

            Debug.Log("Enemy is destroyed!");
            // Enemy is "destroyed" by deactivating it
            gameObject.SetActive(false);

            // Re-enable the enemy after a delay
            Invoke("Respawn", 2f);
        }
    }

    // Called to respawn the enemy
    void Respawn()
    {
        // Reset health and reactivate the enemy
        health = 100;
        gameObject.SetActive(true);
    }
}
