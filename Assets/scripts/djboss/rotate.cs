using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    public int speed = 1;
    public float fireDelay = 0.085f;
    private float timebtwshoot;
    public float BulletSpeed = 5.12f;
    public GameObject bullet;
    public Transform shotPoint1;
   // public Transform shotPoint2;
    Rigidbody2D rb;

    void Update()
    {

            float turnSpeed = speed * Time.deltaTime;
            gameObject.transform.Rotate(Vector3.forward);

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
        GameObject NewBullet = Instantiate(bullet, shotPoint1.position, transform.rotation);
        rb = NewBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint1.up * BulletSpeed, ForceMode2D.Impulse);

/*        timebtwshoot = fireDelay;
        GameObject NewBullet2 = Instantiate(bullet, shotPoint2.position, transform.rotation);
        rb = NewBullet2.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint2.up * BulletSpeed, ForceMode2D.Impulse);*/

    }

}
