using System.Collections;
using UnityEngine;

public class gun3 : MonoBehaviour
{


    public Joystick joystick;
    public GameObject gun;
    private Vector3 difference;
    public float offset;
    private float rotz;
    public GameObject bullet;
    public Transform shotPoint;
    public float fireDelay = 0.22f;
    private float timebtwshoot;
    Rigidbody2D rb;
    public float BulletSpeed = 13f;
    public AudioSource ShootSound1;
    public AudioSource ShootSound2;

    void Start()
    {
    }


    void Update()
    {
        if (Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
        {
            rotz = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        }


        if (timebtwshoot <= 0)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                Shoot();
            }
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
            ShootSound1.Play();
        }
        else
        {
            ShootSound2.Play();
        }
        
    }
}
