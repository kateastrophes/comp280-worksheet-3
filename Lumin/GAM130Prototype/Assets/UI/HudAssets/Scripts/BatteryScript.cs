using UnityEngine;
using UnityEngine.UI;

public class BatteryScript : MonoBehaviour
{
    public int batteries = 5;
    [Range (0.1f,20)]
    public float decreaseAmmount = 0.1f;
    public bool torchUsed = false;    
    public float displayAmmount;
    private bool batteryPickup = false;
    private int fullCharge = 100;
    private float currentCharge = 0;

    public Image BatteryBar;   
    public Text BattCountDisplay; // no longer displayed as text 

    private void Awake()
    {        
        UpdateBattDisplay();
    }

    private void AddBattery()
    {
        batteries += 1;
        batteryPickup = false;
        UpdateBattDisplay();
    }

    private void UsePower()  //decrease battery charge value as torch is used. 
    {
        if ( batteries == 0  && currentCharge <= 0)
        {
            currentCharge = 0;
        }
        else {
            if (torchUsed)
            {
                if (currentCharge <= 0)
                {
                    ChangeBattery();
                }
                else
                {
                    currentCharge = currentCharge - decreaseAmmount * Time.deltaTime;                    
                }
            }
        }
    }

    private void ChangeBattery() 
    {
        if (batteries == 0) // Error check if no batteries. 
        {
            //stop flashlight
            Debug.Log("stop flashlight");
        }
        if (batteries > 0)
        {
            batteries -= 1;
            currentCharge = fullCharge; // remove 1 battery reset charge
            UpdateBattDisplay();
        }                
    }

    private void UpdateBattDisplay()
    {
        BattCountDisplay.text = string.Format("{0}", batteries);
    }

    void Update()
    {
        if (batteryPickup)
        {
            AddBattery();
        }

        UsePower();        
        displayAmmount = currentCharge / fullCharge; // produces a number between 0-1 can be used to represent percentage
        BatteryBar.fillAmount = displayAmmount;        
    }
}
