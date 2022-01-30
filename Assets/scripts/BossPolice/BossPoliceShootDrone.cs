using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPoliceShootDrone : MonoBehaviour
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
    public GameObject[] Player;
    public AudioSource shoot1Sound;
    public AudioSource shoot2Sound;

    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player[0].transform.position, speed * Time.deltaTime);

        difference = Player[0].transform.position - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //gun.transform.RotateAround(Player.transform.localScale, new Vector3(0, 0, 1), 90 * Time.deltaTime);

        if (Player[0].transform.position.x < Enemy.transform.position.x)
        {
            Enemy.transform.localScale = new Vector3(1f, Enemy.transform.localScale.y, Enemy.transform.localScale.z);
        }
        else
        {
            Enemy.transform.localScale = new Vector3(-1f, Enemy.transform.localScale.y, Enemy.transform.localScale.z);
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
}