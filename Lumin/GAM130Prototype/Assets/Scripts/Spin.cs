using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float m_speed = 10f;

    
    void Update()
    {
        gameObject.transform.Rotate(0f,  Time.deltaTime * m_speed, 0f);
    }
}
