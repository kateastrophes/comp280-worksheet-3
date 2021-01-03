using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoorOpenZone : MonoBehaviour
{

    public GameObject Player;
    public Animator m_doorAnimator;
    public GameObject m_doorCollider;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            m_doorAnimator.SetBool("Open", true);
            m_doorCollider.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            m_doorAnimator.SetBool("Open", false);
            m_doorCollider.SetActive(true);
        }
    }


}
