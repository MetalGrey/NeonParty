using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private string SceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneName = SceneManager.GetActiveScene().name;
            if (SceneName == "SampleScene")
            {
                SceneManager.LoadScene("2");
            }
            else if (SceneName == "2")
            {
                SceneManager.LoadScene("lobby");
            }
        }
    }
}
