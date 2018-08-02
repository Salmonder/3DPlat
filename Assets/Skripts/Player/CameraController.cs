using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;
    Vector3 offset;
    Vector3 startPos;
    Vector3 start2Now;
    public float smooth = 0.2f;


	void Start () {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
        startPos = player.transform.position;
             
	}

    private void Update()
    {
        start2Now = player.transform.position - startPos;
    }


    void LateUpdate () {
        transform.position = (player.transform.position + offset) - new Vector3(0,start2Now.y * smooth,0);
        transform.LookAt(player.transform);
	}
}
