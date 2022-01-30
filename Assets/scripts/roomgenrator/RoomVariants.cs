using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomsVariants : MonoBehaviour
{
    public GameObject[] topRoom;
    public GameObject[] LeftpRoom;
    public GameObject[] RightRoom;
    public GameObject[] BottomRoom;

    public GameObject bossroom;
    [HideInInspector] public List<GameObject> rooms;


    private void Start()
    {
        StartCoroutine(RandomSpawner());
    }
    IEnumerator RandomSpawner()
    {
        yield return new WaitForSeconds(5f);
        RoomsGenerator lastRoom = rooms[rooms.Count - 1].GetComponent<RoomsGenerator>();
        int rand = Random.Range(0, rooms.Count - 2);
        Instantiate(bossroom, rooms[rand].transform.position, Quaternion.identity);
    }
    
}
