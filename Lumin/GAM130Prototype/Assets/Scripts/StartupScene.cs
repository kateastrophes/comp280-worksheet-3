using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
    }

}
