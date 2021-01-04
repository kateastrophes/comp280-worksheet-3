using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    [Range(0.1f, 1200)]
    public float dayLength = 60f;
    [SerializeField]
    public int hours;
    [SerializeField]
    public int minutes;

    private float timeOfDay;
    private float startOfDay;
    private float rotateAmount; 


    
    //day length 6 mins 
    void Start()
    {
        timeOfDay = 0;
        rotateAmount = 0;

        startOfDay = Time.time;
    }

    public float getRotateAmount()
    {
        return rotateAmount;
    }
    
    void Update()
    {
        timeOfDay = Time.time - startOfDay;

        if (timeOfDay >= dayLength)
        {           
            timeOfDay -= dayLength;
            startOfDay = Time.time - timeOfDay;
        }

        rotateAmount = -(360f / dayLength) * timeOfDay;


        // add hours and minutes here.
        hours = (int)(timeOfDay*dayLength/24); // round this down to nearest int
        minutes = (int)(dayLength - hours *24); // round this down to nearest 10/15 mins
        Debug.Log(hours + ":" + minutes + "Hours and minutes");

    }
}
