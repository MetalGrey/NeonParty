using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //public GameObject player;
    public GameObject go;
    public int currethp;
    public float currentspeed;
    public bool BGun1 = false;
    public bool BGun2 = false;
    public bool BGun3 = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //Debug.Log(go);
        go = GameObject.Find("player");
        player playerscript = go.GetComponent<player>();
        currentspeed = playerscript.speed;
        currethp = playerscript.Life;
        ChangeWeapon changescript = go.GetComponent<ChangeWeapon>();
        GameObject gun1 = changescript.gun1;
        GameObject gun2 = changescript.gun2;
        GameObject gun3 = changescript.gun3;

        if (gun1.activeInHierarchy == true)
        {
            BGun1 = true;
        }
        else if (gun2.activeInHierarchy == true)
        {
            BGun2 = true;
        }
        else if (gun2.activeInHierarchy == true)
        {
            BGun3 = true;
        }
    }
}
