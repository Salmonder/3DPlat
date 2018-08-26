using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToDefaultScene : MonoBehaviour {

    public int WorldNum;

	void Start () {
        PlayerPrefs.SetInt("World", WorldNum);
	}
	

}
