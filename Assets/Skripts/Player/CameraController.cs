using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
             
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
