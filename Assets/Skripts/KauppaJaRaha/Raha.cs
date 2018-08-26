using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raha : MonoBehaviour {

    int raha;

    private void OnTriggerEnter(Collider other)
    {
        raha = PlayerPrefs.GetInt("raha");
        if (other.gameObject.layer == 11)
        {
            PlayerPrefs.SetInt("raha", raha + 1);
        }
    }
}
