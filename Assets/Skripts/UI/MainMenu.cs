using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public string tasoNimi;
    string taso;


    public void PlayGame ()
    {
        SceneManager.LoadScene(taso);
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("World") < 1 )
        {
            PlayerPrefs.SetInt("World", 1);
        }

        taso = tasoNimi + PlayerPrefs.GetInt("World").ToString();
    }
    
    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}
