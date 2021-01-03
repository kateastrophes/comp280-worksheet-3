using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int index;
    public void PlayGame()
    {
        SceneManager.LoadScene(index);
    }

        public void QuitGame()
    {
        Application.Quit();
    }

 
}
