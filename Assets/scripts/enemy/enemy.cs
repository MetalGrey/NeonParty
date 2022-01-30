using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //public GameObject Player;
    public GameObject gun;
    public GameObject Enemy;
    public float speed;
    private Vector3 difference;
    private float rotZ;

    Rigidbody2D rb;
    public GameObject bullet;
    public Transform shotPoint;
    public float fireDelay = 0.4f;
    private float timebtwshoot;
    public float BulletSpeed = 20f;
    public bool issword = false;
    public int Life;
    public GameObject[] Player;
    public GameObject hpplayer;
    public GameObject booster;
    public AudioSource shoot1Sound;
    public AudioSource shoot2Sound;

    private void Start()
    {
        Life = Random.RandomRange(2, 3);
        Player = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player[0].transform.position, speed * Time.deltaTime);

        difference = Player[0].transform.position - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        //gun.transform.RotateAround(Player.transform.localScale, new Vector3(0, 0, 1), 90 * Time.deltaTime);

        if (Player[0].transform.position.x < Enemy.transform.position.x)
        {
            Enemy.transform.localScale = new Vector3(-1f, Enemy.transform.localScale.y, Enemy.transform.localScale.z);
            gun.transform.localScale = new Vector3(-1f, gun.transform.localScale.y, gun.transform.localScale.z);
        }
        else
        {
            if (issword == true)
            {
                gun.transform.localScale = new Vector3(-1f, gun.transform.localScale.y, gun.transform.localScale.z);
            }
            else
            {
                gun.transform.localScale = new Vector3(1f, gun.transform.localScale.y, gun.transform.localScale.z);
            }
            Enemy.transform.localScale = new Vector3(1f, Enemy.transform.localScale.y, Enemy.transform.localScale.z);
            
        }

        if (timebtwshoot <= 0)
        {
            Shoot();  
        }
        else
        {
            timebtwshoot -= Time.deltaTime;
        }
    }
    public void Shoot()
    {
        timebtwshoot = fireDelay;
        GameObject NewBullet = Instantiate(bullet, shotPoint.position, transform.rotation);
        rb = NewBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint.up * BulletSpeed, ForceMode2D.Impulse);

        int RandomSound = Random.RandomRange(0, 2);
        if (RandomSound == 1)
        {
            shoot1Sound.Play();
        }
        else
        {
            shoot2Sound.Play();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Life -= 1;
            if (Life == 0)
            {
                int randRes = Random.RandomRange(0, 7);
                Destroy(gameObject);
                if (randRes == 3)
                {
                    Instantiate(hpplayer, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), transform.rotation);
                }
                else if (randRes == 4)
                {
                    Instantiate(booster, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), transform.rotation);
                }
            }
        }
    }
}

