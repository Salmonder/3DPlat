using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    Vector3 knockBack;
    public float KnockForce = 10;
    public float knockTime = 0.25f;
    public bool hit = false;
    float time = 0;
    Rigidbody rb;
    public float upKnock = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Took damage");

            knockBack = (transform.position - collision.gameObject.transform.position  ).normalized * KnockForce;

            hit = true;

            rb.velocity = Vector3.zero;

            knock();
                    
        }
              

    }

    private void Update()
    {


        if (!hit)
        {
            time = 0;
        }
    }

    private void FixedUpdate()
    {
        if (hit)
        {
            time = time + Time.deltaTime;
            if (time > knockTime)
            {
                
                hit = false;

                

            }
        }
    }
    void knock()
    {
        
        rb.AddForce(Vector3.up * upKnock + new Vector3(knockBack.x, 0, knockBack.z) * KnockForce);
    }

}
