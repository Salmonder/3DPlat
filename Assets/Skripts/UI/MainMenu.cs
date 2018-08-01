using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public string taso;

    public void PlayGame ()
    {
        SceneManager.LoadScene(taso);
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}
