using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPolice : MonoBehaviour
{
    public GameObject[] Player;
    public GameObject gun;
    public GameObject Enemy;
    public float speed;
    private Vector3 difference;
    private float rotZ;

    public Slider slider;
    public int MaxHealth = 40;
    public int currentHealth;
    public GameObject slidergame;

    public GameObject drone0;
    public GameObject shoot1;
    public GameObject portal;

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        currentHealth = MaxHealth;
        SetMaxHealth(MaxHealth);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player[0].transform.position, speed * Time.deltaTime);
        
        difference = Player[0].transform.position - transform.position;       
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);         //+ 170


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
            shoot1.SetActive(true);
        }
        else if (currentHealth == 20)
        {
            drone0.SetActive(true);
        }
        else if (currentHealth == 0)
        {
            Instantiate(portal, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 3f), gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(drone0);
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
