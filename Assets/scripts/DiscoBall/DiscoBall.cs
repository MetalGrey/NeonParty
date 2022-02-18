using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoBall : MonoBehaviour
{
    public GameObject[] Player;
    private Vector3 difference;
    private float rotZ;

    public Slider slider;
    public int MaxHealth = 40;
    public int currentHealth;
    public GameObject slidergame;

    public GameObject shoot360;
    public GameObject portal;

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        currentHealth = MaxHealth;
        SetMaxHealth(MaxHealth);
    }


    public void SetHealth(int healath)
    {
        slider.value = healath;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    private void TakeDamage()
    {
        currentHealth -= 1;
        SetHealth(currentHealth);
        if (currentHealth == 39)
        {
            shoot360.SetActive(true);
        }
        else if (currentHealth == 0)
        {
            Instantiate(portal, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 3f), gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(slidergame);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
    }
}
