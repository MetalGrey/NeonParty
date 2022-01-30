using UnityEngine;

public class BagRooms : MonoBehaviour
{
    public GameObject block;
    public GameObject baglight;
    public bool can;


    private void Start()
    {
        can = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block" && can == true)
        {
            Instantiate(block, transform.GetChild(0).position, Quaternion.identity);
            Instantiate(block, transform.GetChild(1).position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("Touch");
            // can = false;
        }
    }
}
