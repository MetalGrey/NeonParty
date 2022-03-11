using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsAttack : MonoBehaviour
{
    public GameObject[] Player;
    public GameObject Bomb;
    private GameObject CreatedBomb;
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(BombsOverBrodway());
    }
    IEnumerator BombsOverBrodway()
    {
        while (true)
        {

            CreatedBomb = Instantiate(Bomb, new Vector3(Player[0].transform.position.x, Player[0].transform.position.y, Player[0].transform.position.z + 10f), Player[0].transform.rotation);
            yield return new WaitForSeconds(5);

        }


    }
}
