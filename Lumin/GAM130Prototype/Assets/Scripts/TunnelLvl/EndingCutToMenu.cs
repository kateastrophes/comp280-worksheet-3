using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCutToMenu : MonoBehaviour
{
    
    public bool switchScene;
    public int index;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switchScene == true)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
