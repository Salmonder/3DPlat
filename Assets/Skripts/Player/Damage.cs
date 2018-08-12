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
    public int hp;
    public GameObject mesh;
    PlayerController con;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = 2;
        con = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Took damage");

            knockBack = (transform.position - collision.gameObject.transform.position  ).normalized * KnockForce;

            hit = true;

            rb.velocity = Vector3.zero;

            Knock();
            if (hp >= 1)
            {
                hp = hp - 1;
            }                    
        }
              

    }

    private void Update()
    {


        if (!hit)
        {
            time = 0;
        }
        if (hp <= 0)
        {
            Die();
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
    void Knock()
    {
        if (hp >= 1)
        {
            rb.AddForce(Vector3.up * upKnock + new Vector3(knockBack.x, 0, knockBack.z) * KnockForce);
        }
    }

    void Die()
    {
        mesh.SetActive(false);
        con.enabled = false;
        this.enabled = false;

    }

}
