using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    public GameObject bulletBack;
    public GameObject[] bullets;
    public PlayerController player;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        bulletBack.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            bulletBack.SetActive(true);
        }


    }
}
