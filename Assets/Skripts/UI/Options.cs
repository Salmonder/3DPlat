using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {




    public void Restart()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("lives", 3);
    }
}
