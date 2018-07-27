using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    GameObject player;
    Rigidbody rb;

    public bool maassa = false;
    public float jumpHight;
    float jumpDelay = 0;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (jumpDelay <= 0.1)
        {
            jumpDelay = jumpDelay + Time.deltaTime;
        }

        if (maassa && Input.GetButtonDown("Jump") && jumpDelay >= 0.1)
        {
            rb.AddForce(new Vector2(0, jumpHight));
            jumpDelay = 0;
        }

    }


    private void OnCollisionSta(Collision collision)
    {
        
        
            if (collision.gameObject.layer == 9)
            {
                maassa = true;
            }
        
        
    }


    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            maassa = false;
        }
    }
}
