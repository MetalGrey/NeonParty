using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    private bool faceright = true;
    public Joystick joystick;
    private Vector2 moveInput;
    public GameObject gun;
    public GameObject gun2;
    public GameObject gun3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (!faceright && moveInput.x > 0)
        {
            gun.transform.position = new Vector3(gun.transform.position.x + 0.35f, gun.transform.position.y, gun.transform.position.z);
            gun2.transform.position = new Vector3(gun.transform.position.x + 0.15f, gun.transform.position.y, gun.transform.position.z);
            gun3.transform.position = new Vector3(gun.transform.position.x + 0.15f, gun.transform.position.y, gun.transform.position.z);
            Flip();
            
        }
        else if (faceright && moveInput.x < 0)
        {
            gun.transform.position = new Vector3(gun.transform.position.x - 0.35f, gun.transform.position.y, gun.transform.position.z);
            gun2.transform.position = new Vector3(gun.transform.position.x - 0.15f, gun.transform.position.y, gun.transform.position.z);
            gun3.transform.position = new Vector3(gun.transform.position.x - 0.15f, gun.transform.position.y, gun.transform.position.z);
            Flip();
        }
    }
    private void Flip()
    {
        faceright = !faceright;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
