using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] enemyies;
    private int randomPoint;
    private int randomEnemy;
    private float waitToCreat;
    private bool canSpawn;
    private float timer;
    private float timeToWin;
    public float maxTime;
    public GameObject win;
    public Text time;
    

    // Start is called before the first frame update
    void Start()
    {
        waitToCreat = 1;//ilk baþta spawn süresi
        timer = 0;
        canSpawn = true;
        timeToWin = maxTime;

    }

    // Update is called once per frame
    void Update()
    {
        timeToWin -= Time.deltaTime;
        if ((timeToWin)%2 <=0)
        {
            waitToCreat = 0.5f;
        }
        time.text = timeToWin.ToString();
        if (timeToWin <= 0  )
        {
            win.SetActive(true);
            timeToWin = 0;
        }
        randomPoint = Random.Range(0, spawnPoint.Length);
        randomEnemy = Random.Range(0, enemyies.Length);

        if (canSpawn == true)
        {
            Instantiate(enemyies[randomEnemy], spawnPoint[randomPoint].position, Quaternion.identity);
            canSpawn = false;
        }
        if (!canSpawn)
        {
            timer += Time.deltaTime;
            if (timer >= waitToCreat)
            {
                canSpawn = true;
                timer = 0;
            }
        }
       

    }
}
