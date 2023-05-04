using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D bulletRb;
    public Vector3 mousePos;
    public Vector2 shotPosition;
    public float damageBullet;

    public float[] bulletRange;
    public ScriptableWeapon[] weapons;
    public int currentState;
    

    PlayerController player;
  

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();//Prefab oldu�u i�in b�yle almal�y�z.
        currentState = player.currentWeapon;//Ka��nc� silahta oldu�umuzu al�yoruz


        shotPosition = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        bulletRb.velocity = direction.normalized * bulletSpeed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        

    }
    
    private void Update()
    {

        BulletRange(weapons[currentState].range);
    }
    public void BulletRange(float range)
    {
        if (Vector2.Distance(transform.position,shotPosition) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(weapons[currentState].damage);
                Destroy(gameObject);
            }

        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(weapons[currentState].damage);
            Destroy(gameObject);
        }

    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
 

