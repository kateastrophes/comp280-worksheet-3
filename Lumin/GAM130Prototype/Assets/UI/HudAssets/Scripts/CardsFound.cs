using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsFound : MonoBehaviour
{
   public bool tealCardFound = false;
   public bool blueCardFound = false;

    public GameObject iconsRegion;
    
    [SerializeField]
    private Image Bluecard;
    [SerializeField]
    private Image Tealcard;

    

    private void CheckCardsFound()
    {
        if (blueCardFound)
        {
            Color greenC = Bluecard.color;
            greenC.a = 1f;
            Bluecard.color = greenC;
        }
        else
        {
            Color blueC = Bluecard.color;
            blueC.a = 0.3f;
            Bluecard.color = blueC;

        }

        if (tealCardFound)
        {
            Color redC = Tealcard.color;
            redC.a = 1f;
            Tealcard.color = redC;
        }
        else
        {
            Color tealC = Tealcard.color;
            tealC.a = 0.3f;
            Tealcard.color = tealC;

        }
    }


    

    // Update is called once per frame
    void Update()
    {     
        CheckCardsFound();

        if (tealCardFound || blueCardFound)
        {
            iconsRegion.SetActive(true);
        }
        else
        {
            iconsRegion.SetActive(false);
        }
    }
}
