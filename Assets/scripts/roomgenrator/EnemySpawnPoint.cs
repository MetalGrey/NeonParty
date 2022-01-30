using System.Collections;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{

    public GameObject[] spawnPoints;
    public GameObject[] Enemy;
    public int howmany;
    public int rand;


    void Start()
    {
        howmany = Random.RandomRange(3, 6);
        StartCoroutine(TestCoroutine());

    }

    IEnumerator TestCoroutine()
    {
        for (int i = 0; i < howmany; i++)
        {
            rand = Random.RandomRange(0, 2);
            Instantiate(Enemy[rand], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
