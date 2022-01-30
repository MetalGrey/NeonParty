using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBoss : MonoBehaviour
{

    [SerializeField] private float defDinstanceRay = 100;
    public LineRenderer m_line;
    Transform m_transform;
    public Transform laserPoint;

    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    void Shoot()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserPoint.position, transform.right);
            Draw2DRay(laserPoint.position, _hit.point);

        }
        else
        {
            Draw2DRay(laserPoint.position, laserPoint.transform.right * defDinstanceRay);
        }

    }

    void Draw2DRay(Vector2 startPos, Vector2 endpos)
    {
        m_line.SetPosition(0, startPos);
        m_line.SetPosition(1, endpos);
    }

    void Update()
    {
        Shoot();
    }
}
