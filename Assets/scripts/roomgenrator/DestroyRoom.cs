using UnityEngine;

public class DestroyRoom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "GeneratedRoom")
        {
            Destroy(collider.gameObject);
        }
    }
}
