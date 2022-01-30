using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public Slider slider;
    public int MaxHealth = 40;
    public int currentHealth;
    public GameObject disk1;
    public GameObject disk2;
    public GameObject Shoot0;
    public GameObject Shoot1;
    public GameObject Shoot2;
    public GameObject slidergame;
    public GameObject portal;
    private void Start()
    {
        currentHealth = MaxHealth;
        SetMaxHealth(MaxHealth);
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int healath)
    {
        slider.value = healath;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentHealth -= 1;
        SetHealth(currentHealth);
        if (currentHealth == 39)
        {
            Shoot0.SetActive(true);
            Shoot1.SetActive(false);
            Shoot2.SetActive(false);
        }
        else if(currentHealth == 30)
        {
            Shoot0.SetActive(true);
            Shoot1.SetActive(false);
            Shoot2.SetActive(true);
        }
        else if (currentHealth == 25)
        {
            disk2.SetActive(true);
        }
        else if (currentHealth == 20)
        {
            Shoot0.SetActive(false);
            Shoot1.SetActive(true);
            Shoot2.SetActive(false);
        }
        else if (currentHealth == 0)
        {
            Instantiate(portal, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 3f), gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(slidergame); 
        }

    }
}
