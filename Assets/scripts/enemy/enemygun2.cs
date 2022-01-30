using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygun2 : MonoBehaviour
{
    private Animator anim;
    public GameObject gun2;
    public GameObject[] Player;
    public GameObject Enemy;


    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("playgun2", true);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("playgun2", false);
        }
    }
}
