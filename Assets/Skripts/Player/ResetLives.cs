using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLives : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("lives", 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
