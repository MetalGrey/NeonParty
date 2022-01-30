using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dialogueEnter : MonoBehaviour
{
    public GameObject dialogebox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogebox.SetActive(true);
        }       
    }
}
