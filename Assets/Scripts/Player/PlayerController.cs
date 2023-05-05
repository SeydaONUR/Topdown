using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator anim;

    public Transform shotPoint;
    public BulletController bt;//another bullet
    private Vector3 mousePose;
    private bool canShot;
    private float currentTime;
    public int[] bulletNumber;//current bullet number
    public int[] maxBulletNumber;
    public BulletController shotgun;//for shotgu bullet
    
    public int currentWeapon;
    public float[] range;//for bullet area
    public float damage;

    public Text scoreBoard;
    public int score;

    public Text Item;

    public GameObject[] bulletBack;//Numver of bullet
    public GameObject[] bullets;

    public BombController molotov;//molotof
    private bool canBomb;
    public GameObject tutorial;

    public GameObject escMenu;


    public ScriptableWeapon[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(true);
        canBomb = true;
        bulletBack[0].SetActive(true);
        currentTime = 0;
        score = 0;
        canShot = true;
        currentWeapon = 0;
        escMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text = score.ToString();
        Explain(weapons[currentWeapon].explanation.ToString());
        ChangeWeapon();
        Shoot();
        Molotov();
        Movement();
        WeaponInfo();
        //wait for next shot
        if (!canShot)
        {
            currentTime += Time.deltaTime;
            if (currentTime >=weapons[currentWeapon].waitToShot )
            {
                currentTime = 0;
                canShot = true;
            }
        }
        //change weapon animation
        if (currentWeapon==0)
        {
            anim.SetTrigger("Sniper");
           
        }
        else if (currentWeapon ==1)
        {
            anim.SetTrigger("Shotgun");
        }
        else
        {
            anim.SetTrigger("Gatling");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && escMenu.activeSelf==false)
        {
            escMenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && escMenu.activeSelf == true)
        {
            escMenu.SetActive(false);
        }

    }

    public void Movement()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);


        if (rb.velocity.x <= 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        anim.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Vertical", rb.velocity.y);
    }
    public void ChangeWeapon()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))//Silah deðiþtiriyorum
        {
            tutorial.SetActive(false);
            bulletBack[currentWeapon].SetActive(false);
            for (int i = 0; i <= weapons[currentWeapon].ammo - 1; i++)
            {
                bullets[i].SetActive(false);

            }
            currentWeapon++;
            if (currentWeapon == weapons.Length)
            {
                currentWeapon = 0;
            }
            bulletBack[currentWeapon].SetActive(true);
        }
    }
    public void WeaponInfo()
    {
        // Ammo
        //Mevcut silahýn mermi sayýsýný en yüksek mermi sayýsý olarak atýyoruz
        maxBulletNumber[currentWeapon] = weapons[currentWeapon].ammo;
        damage = weapons[currentWeapon].damage;
        for (int i = 0; i <= bulletNumber[currentWeapon] - 1; i++)
        {
            bullets[i].SetActive(true);
        }
        if (bulletNumber[currentWeapon] <= 0 || Input.GetKeyDown(KeyCode.R)) //Reload 
        {
            currentTime += Time.deltaTime;
            if (currentTime >= weapons[currentWeapon].reloadTime)
            {
                currentTime = 0;
                bulletNumber[currentWeapon] = maxBulletNumber[currentWeapon]; //Þarjör deðiþtirme
            }

        }


    }
    public void Shoot()
    {
        if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) && canShot == true && bulletNumber[currentWeapon] > 0)
        {
            if (currentWeapon == 1)
            {
                Instantiate(shotgun, shotPoint.position, Quaternion.identity);

            }
            else
            {
                Instantiate(bt, shotPoint.position, Quaternion.identity);

            }
            bullets[bulletNumber[currentWeapon] - 1].SetActive(false);//Mermi scriptimi düþüyorum
            bulletNumber[currentWeapon] -= 1;//her ateþ ettiðimde mermi sayýsýný deðiþtiriyorum.
            canShot = false;
        }
    }
    public void Molotov()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && canBomb == true)
        {
            Instantiate(molotov, shotPoint.position, Quaternion.identity);
            canBomb = false;//you can only use it once
        }
    }
    public void Explain(string exp)
    {
        Item.text = exp;
    }
    public void wait(float time)
    {
        time -= Time.deltaTime;
        if (time <=0)
        {
            canShot = true;
        }
    }
}
