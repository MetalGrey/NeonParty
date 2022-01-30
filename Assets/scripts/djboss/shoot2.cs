using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot2 : MonoBehaviour
{

    public float fireDelay = 0.07f;
    private float timebtwshoot;
    public float BulletSpeed = 3f;
    public GameObject bullet;
    public Transform shotPoint1;
    // public Transform shotPoint2;
    Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {

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
