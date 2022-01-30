using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject particle;
    public Sprite [] sprites;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        int i = Random.RandomRange(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
    }
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
