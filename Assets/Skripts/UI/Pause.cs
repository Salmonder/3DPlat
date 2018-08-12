using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    bool paused = false;
    public GameObject PauseMenu;

    private void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            
        }
        if (paused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    


    
}
