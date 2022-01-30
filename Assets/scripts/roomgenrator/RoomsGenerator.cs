using UnityEngine;

public class RoomsGenerator : MonoBehaviour
{

    public Direction direction;
    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }

    private RoomVariants variants;
    private int rand;
    private bool spawned = false;
    private float waitTime = 3f;
    private GameObject startroom;
    private GameObject room;


    void Awake()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.2f); // 0.2 optimalno
    }
    private void Start()
    {
        
    }

    public void Spawn()
    {
        if (!spawned)
        {
            if (direction == Direction.Top)
            {
                rand = Random.Range(0, variants.topRoom.Length);
                room = Instantiate(variants.topRoom[rand], transform.position, variants.topRoom[rand].transform.rotation);
                variants.rooms.Add(room);
            }
            else if (direction == Direction.Bottom)
            {
                rand = Random.Range(0, variants.BottomRoom.Length);
                room = Instantiate(variants.BottomRoom[rand], transform.position, variants.BottomRoom[rand].transform.rotation);
                variants.rooms.Add(room);
            }
            else if (direction == Direction.Right)
            {
                rand = Random.Range(0, variants.RightRoom.Length);
                room = Instantiate(variants.RightRoom[rand], transform.position, variants.RightRoom[rand].transform.rotation);
                variants.rooms.Add(room);
            }
            else if (direction == Direction.Left)
            {
                rand = Random.Range(0, variants.LeftpRoom.Length);
                room = Instantiate(variants.LeftpRoom[rand], transform.position, variants.LeftpRoom[rand].transform.rotation);
                variants.rooms.Add(room);
            }
            spawned = true;
        }
        
    }


    private void Update()
    {
        variants.rooms.RemoveAll(x => x == null);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomPoint") && other.GetComponent<RoomsGenerator>().spawned)
        {
            Destroy(gameObject);
        }
    }
}
