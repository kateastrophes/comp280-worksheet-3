using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelLvlLightControl : MonoBehaviour
{

    public GameObject Headtorch;
    public bool onOff;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            if (onOff == true)
            {
                Headtorch.SetActive(true);
            }
            else
            {
                Headtorch.SetActive(false);
            }
        }
    }
}
