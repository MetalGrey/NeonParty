using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    public GameObject[] light;
    public GameObject baglight;
    public GameObject EnemySpawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enterboss")
        {
            //EnemySpawn.SetActive(true);
            for (int i = 0; i < light.Length; i++)
            {
                light[i].SetActive(true);
            }
            baglight.SetActive(true);
        }
    }
}
