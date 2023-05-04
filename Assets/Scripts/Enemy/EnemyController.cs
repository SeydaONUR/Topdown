using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public PlayerController player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        moveEnemy(movement);

        if (rb.velocity.x <= 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        anim.SetFloat("Horizontal",direction.x);
        anim.SetFloat("Vertical", direction.y);
        
        if (direction.y <= -0.001)
        {
            transform.localScale = new Vector3(1,-1,1);
        }
        
    }
    public void moveEnemy(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * enemySpeed * Time.deltaTime));
    }
}
