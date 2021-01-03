using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonousPlant : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.current.EnterPoisenCollision();
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.current.ExitPoisenCollision();
        }
    }


}
