using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Shoot360 : MonoBehaviour
{

    public float speed = 0.72f;
    public float fireDelay = 0.16f;
    private float timebtwshoot;
    public float BulletSpeed = 6f;
    public GameObject bullet;
    public Transform shotPoint1;
    public Transform shotPoint2;
    public Transform shotPoint3;
    // public Transform shotPoint2;
    Rigidbody2D rb;

    void Update()
    {

        float turnSpeed = speed * Time.deltaTime;
        //gameObject.transform.Rotate(Vector3.forward);
        gameObject.transform.Rotate(0, 0, 360f * turnSpeed);

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

        GameObject NewBullet2 = Instantiate(bullet, shotPoint2.position, transform.rotation);
        rb = NewBullet2.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint2.up * BulletSpeed, ForceMode2D.Impulse);

        GameObject NewBullet3 = Instantiate(bullet, shotPoint3.position, transform.rotation);
        rb = NewBullet3.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint3.up * BulletSpeed, ForceMode2D.Impulse);
    }
}
