using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private string SceneName;
    public GameObject Data;
    public GameObject datalast;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneName = SceneManager.GetActiveScene().name;
            if (SceneName == "SampleScene")
            {

                datalast = GameObject.Find("Data(Clone)");
                Destroy(datalast);
                Instantiate(Data);
                SceneManager.LoadScene("2");
            }
            else if (SceneName == "2")
            {
                datalast = GameObject.Find("Data(Clone)");
                Destroy(datalast);
                Instantiate(Data);
                SceneManager.LoadScene("3");
            }
            else if (SceneName == "3")
            {
                datalast = GameObject.Find("Data(Clone)");
                Destroy(datalast);
                Instantiate(Data);
                SceneManager.LoadScene("lobby");
            }
        }
    }
}
