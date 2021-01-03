using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPickup : MonoBehaviour
{
    public JornalData jornalData;

    private void Awake()
    {
        if (jornalData == null)
        {
            return;
        }
        if (jornalData.collected == true)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            JornalScript.instance.AddLog(jornalData.logTitle);
            Destroy(gameObject);
        }
    }
}
