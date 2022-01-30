using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot360 : MonoBehaviour
{

    [SerializeField]
    Transform center;

    [SerializeField]
    float radius = 2f, angularSpeed = 2f;

    float X, Y, angle = 0f;



    void Update()
    {
        X = center.position.x + Mathf.Cos(angle) * radius;
        Y = center.position.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector2(X, Y);
        angle = angle + Time.deltaTime * angularSpeed;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
