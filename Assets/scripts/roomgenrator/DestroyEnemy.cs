﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy") || (collision.gameObject.tag == "EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
