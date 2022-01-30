using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
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
