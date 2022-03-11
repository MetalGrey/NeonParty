using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject particle;
    public GameObject trigger;
    void Start()
    {
        StartCoroutine(BombWillBOOM());
    }
    IEnumerator BombWillBOOM()
    {
        yield return new WaitForSeconds(3);
        particle.SetActive(true);
        trigger.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
