using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.tag == "block" || collision.gameObject.tag == "bagblock" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "djboss" || collision.gameObject.tag == "blockboss" || collision.gameObject.tag == "bossPolice" || collision.gameObject.tag == "DiscoBall")
        {
            Instantiate(particle, BulletPrefab.transform.position, BulletPrefab.transform.rotation);
            Destroy(BulletPrefab);
        }   
    }
}
