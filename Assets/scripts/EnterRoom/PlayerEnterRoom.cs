using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterRoom : MonoBehaviour
{
    public GameObject[] Door;
    public GameObject EnemySpawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enterboss")
        {
            EnemySpawn.SetActive(true);
            for (int i = 0; i < Door.Length; i++)
            {
                Door[i].SetActive(true);
            }
        }

    }
}


/*public GameObject[] Door;
public GameObject EnemyEnter;
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Player")
    {
        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].SetActive(true);
        }
        StartCoroutine(EnemyDieIenum());
    }

}
IEnumerator EnemyDieIenum()
{
    yield return new WaitForSeconds(1f);
    EnemyEnter.SetActive(true);
}*/