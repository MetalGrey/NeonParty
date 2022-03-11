using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBossDoor : MonoBehaviour
{
    public GameObject[] bossDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < bossDoor.Length; i++)
            {
                bossDoor[i].SetActive(true);
            }
        }

    }

}
