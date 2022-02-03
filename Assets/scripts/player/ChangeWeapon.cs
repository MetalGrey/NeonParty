using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject playerobj;

    private void Start()
    {

    }
    private void Update()
    {
        playerobj = GameObject.Find("player");
        player playerscript = playerobj.GetComponent<player>();
        bool Bgun1 = playerscript.Bgun1;
        bool Bgun2 = playerscript.Bgun2;
        bool Bgun3 = playerscript.Bgun3;
        //Debug.Log(Bgun1 + " " + Bgun2 + " " + Bgun3);
        if (Bgun1 == true)
        {
            gun2.SetActive(false);
            gun1.SetActive(true);
            gun3.SetActive(false);
        }
        else if (Bgun2 == true)
        {
            gun1.SetActive(false);
            gun3.SetActive(false);
            gun2.SetActive(true);
        }
        else if (Bgun3 == true)
        {
            gun2.SetActive(false);
            gun1.SetActive(false);
            gun3.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "gun2")
        {
            gun1.SetActive(false);
            gun3.SetActive(false);
            gun2.SetActive(true);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "gun1")
        {
            gun2.SetActive(false);
            gun1.SetActive(true);
            gun3.SetActive(false);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "gun3")
        {
            gun2.SetActive(false);
            gun1.SetActive(false);
            gun3.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
