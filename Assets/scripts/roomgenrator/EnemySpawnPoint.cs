using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{

    public GameObject[] spawnPoints;
    public GameObject[] Enemy;
    public List<GameObject> SpawnedEnemies = new List<GameObject>();
    private GameObject EnemyRand;
    public int howmany;
    public int rand;
    public GameObject Door;
    private bool ReadyToClose = false;


    void Start()
    {
       
        howmany = Random.RandomRange(3, 6);
        StartCoroutine(TestCoroutine());

    }

    IEnumerator TestCoroutine()
    {
        for (int i = 0; i < howmany; i++)
        {
            ReadyToClose = true;
            rand = Random.RandomRange(0, 2);
            EnemyRand = Instantiate(Enemy[rand], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            SpawnedEnemies.Add(EnemyRand);
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void Update()
    {
        SpawnedEnemies.RemoveAll(x => x == null);
        if (SpawnedEnemies.Count == 0 && ReadyToClose == true)
        {
            Door.SetActive(false);
        }
    }
}
