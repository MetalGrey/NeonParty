    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block" || collision.gameObject.tag == "bagblock")
        {
            Instantiate(particle, BulletPrefab.transform.position, BulletPrefab.transform.rotation);
            Destroy(BulletPrefab);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Instantiate(particle, BulletPrefab.transform.position, BulletPrefab.transform.rotation);
            Destroy(BulletPrefab);
        }
    }
}
