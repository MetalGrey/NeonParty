using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public ControlType controlType;
    public float speed;
    public Joystick joystick;
    public Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public GameObject gun;
    public int Life = 6;
    private float timesec = 0;
    public enum ControlType { PC, Adnroid }

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public Sprite shp1;
    public Sprite shp2;
    public Sprite shp3;

    public AudioSource hit1;
    public AudioSource hit2;
    public GameObject AnimObj;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if (controlType == ControlType.Adnroid)
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        moveVelocity = moveInput.normalized * speed;
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            AnimObj.GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            AnimObj.GetComponent<Animator>().SetBool("run", false);
        }

        if (Life == 6)
        {
            hp1.GetComponent<Image>().sprite = shp1;
            hp2.GetComponent<Image>().sprite = shp1;
            hp3.GetComponent<Image>().sprite = shp1;
        }
        else if (Life == 5)
        {
            hp1.GetComponent<Image>().sprite = shp2;
            hp2.GetComponent<Image>().sprite = shp1;
            hp3.GetComponent<Image>().sprite = shp1;
        }
        else if (Life == 4)
        {
            hp1.GetComponent<Image>().sprite = shp3;
            hp2.GetComponent<Image>().sprite = shp1;
            hp3.GetComponent<Image>().sprite = shp1;
        }
        else if (Life == 3)
        {
            hp1.GetComponent<Image>().sprite = shp3;
            hp2.GetComponent<Image>().sprite = shp2;
            hp3.GetComponent<Image>().sprite = shp1;
        }
        else if (Life == 2)
        {
            hp1.GetComponent<Image>().sprite = shp3;
            hp2.GetComponent<Image>().sprite = shp3;
            hp3.GetComponent<Image>().sprite = shp1;
        }
        else if (Life == 1)
        {
            hp1.GetComponent<Image>().sprite = shp3;
            hp2.GetComponent<Image>().sprite = shp3;
            hp3.GetComponent<Image>().sprite = shp2;
        }
        else
        {
            hp1.GetComponent<Image>().sprite = shp3;
            hp2.GetComponent<Image>().sprite = shp3;
            hp3.GetComponent<Image>().sprite = shp3;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(Life);
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Life -= 1;
            int RandomSound = Random.RandomRange(0, 2);
            if (RandomSound == 1)
            {
                hit1.Play();
            }
            else
            {
                hit2.Play();
            }

            //Debug.Log(Life);
            if (Life == 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        else if (collision.gameObject.tag == "hp1")
        {
            if (Life < 6)
            {
                Life++;
                Destroy(collision.gameObject);
            }           
        }
        else if (collision.gameObject.tag == "booster")
        {
            speed = speed + 0.5f;
            Destroy(collision.gameObject);
        }
        

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemySword")
        {
            Debug.Log("SWORD");
            if (timesec < Time.time)
            {
                timesec = Time.time + 1;
                Life -= 1;
                int RandomSound = Random.RandomRange(0, 2);
                if (RandomSound == 1)
                {
                    hit1.Play();
                }
                else
                {
                    hit2.Play();
                }
                if (Life == 0)
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }


}
