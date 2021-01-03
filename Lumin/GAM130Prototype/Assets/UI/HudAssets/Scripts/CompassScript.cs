using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{

    public GameObject clock;

    private float rotateAmount;
    private ClockScript clockScript;
 
    Vector3 dir;

    private void Start()
    {
        clockScript = clock.GetComponent<ClockScript>();
    }

    private void Update()
    {

        rotateAmount = clockScript.getRotateAmount();
        Debug.Log(rotateAmount);

        
        dir.z = rotateAmount;
        transform.localEulerAngles = dir;
    }


    

}
