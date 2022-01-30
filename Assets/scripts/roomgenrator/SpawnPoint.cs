using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] Enemy;
    public int enemycount;
    public bool canspawn = true;
    public GameObject Spawn;

    void Start()
    {
        enemycount = Random.RandomRange(1, 4);
        StartCoroutine(EnemyCoroutine());
    }


    void Update()
    {
        
    }

    IEnumerator EnemyCoroutine()
    {
        //Debug.Log(enemycount);
        while (true)
        {
            Debug.Log(enemycount);
            if (enemycount == 0)
            {
                break;
            }
            int EnemyRandom = Random.RandomRange(0, Enemy.Length);
            Instantiate(Enemy[EnemyRandom], Spawn.transform.position, Spawn.transform.rotation);
            enemycount -= 1;
            yield return new WaitForSeconds(7f);
        }
    }
}
