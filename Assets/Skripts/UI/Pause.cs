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
            OpenPauseMenu();
        }
    }
    void OpenPauseMenu()
    {
        if (paused)
        {
            PauseMenu.SetActive(true);
        }
        else
        {
            PauseMenu.SetActive(false);
        }

    }
}
