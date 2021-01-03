using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSceneDoorOpenScript : MonoBehaviour
{

    public Animator m_doorAnimator;



    // Start is called before the first frame update
    void Start()
    {
        m_doorAnimator.SetBool("Open", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
