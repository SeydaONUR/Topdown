using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float enemyHealth;
    public PlayerController player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }


    public void DamageEnemy(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <=0)
        {
            player.score += 10;
            Destroy(gameObject);
        }
    }
}
