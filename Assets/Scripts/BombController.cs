using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D bulletRb;
    public Vector3 mousePos;
    public float damageMolotov;
    public FlameCpntroller flame;
    //public GameObject flame2;

    private void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        bulletRb.velocity = direction.normalized * bulletSpeed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            //collision.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damageMolotov);
            Destroy(gameObject);
            Instantiate(flame,transform.position,Quaternion.identity);
        }
    }
}
