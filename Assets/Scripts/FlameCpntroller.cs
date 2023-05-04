using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCpntroller : MonoBehaviour
{
    public float damage;
    public float time;
    private float timeCounter;
    public float range;
    public Transform burningPoint;
    public LayerMask Enemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= time)
        {
            Destroy(gameObject);
        }
       
        
     
        Collider2D[] burningEnemy = Physics2D.OverlapCircleAll(burningPoint.transform.position,range,Enemy);
        if (burningEnemy.Length != null)
        {
            foreach (Collider2D col in burningEnemy )
            {
                col.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage);
            }
        }
    }
    
}
