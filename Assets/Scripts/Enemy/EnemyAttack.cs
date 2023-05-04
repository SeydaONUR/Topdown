using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerHealthController>().DamagePlayer(damageAmount);
        }
    }
}
