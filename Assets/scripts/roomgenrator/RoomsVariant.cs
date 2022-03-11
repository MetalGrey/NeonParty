using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RoomVariants : MonoBehaviour
{
    public GameObject[] topRoom;
    public GameObject[] LeftpRoom;
    public GameObject[] RightRoom;
    public GameObject[] BottomRoom;

    public GameObject bossroom;
    public List<GameObject> rooms;
    private GameObject bossposition;
    public GameObject Cleaner;
    private string SceneName;

    private void Start()
    {
        StartCoroutine(RandomSpawner());
        SceneName = SceneManager.GetActiveScene().name;
}
    IEnumerator RandomSpawner()
    {
        yield return new WaitForSeconds(5f);
        RoomsGenerator lastRoom = rooms[rooms.Count - 1].GetComponent<RoomsGenerator>();
        int rand = Random.Range(rooms.Count - 2, rooms.Count - 1);
        Debug.Log(rand);
        Debug.Log(rooms[rand].transform.position);
        //Instantiate(bossroom, rooms[rand].transform.position, Quaternion.identity);
        bossroom.SetActive(true);
        PositonBoss(rooms[rand]);
        StartCoroutine(DeleteCleaner());
    }

    IEnumerator DeleteCleaner()
    {
        yield return new WaitForSeconds(2f);
        Destroy(Cleaner);
    }
    private void PositonBoss(GameObject roomposition)
    {
        if (SceneName == "SampleScene")
        {
            bossposition = GameObject.FindGameObjectWithTag("djboss");
        }
        else if (SceneName == "2")
        {
            bossposition = GameObject.FindGameObjectWithTag("bossPoliceObj");
        }
        else if (SceneName == "3")
        {
            bossposition = GameObject.FindGameObjectWithTag("DiscoBall");
        }
        bossposition.transform.position = new Vector3(roomposition.transform.position.x + 2.25f, roomposition.transform.position.y - 3.25f, roomposition.transform.transform.position.z);
    }
}