using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float moveX;
    float moveZ;
    Vector3 movement;
    Rigidbody rb;
    public float maxSpeed = 30f;     //liikkumiseen

    bool maassa = false;
    public float jumpHight;         
    float jumpDelay = 0;                            //hyppimiseen

    Vector3 ylös = Vector3.up;
    public float turnSmooth;
    Quaternion suunta;
    float viive;                            //kääntyminen

    Animator anim;


    Damage damage;
    bool hit;                               //Damage


    bool dodge = false;
    public float dodgetime = 0.25f;
    float doddgeCoolDown;
    float timer;
    
    



    private void Start()
    {
        damage = GetComponent<Damage>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }




    void FixedUpdate()
    {
        if (!hit)
        {
            rb.velocity = new Vector3(movement.x * maxSpeed, rb.velocity.y, movement.z * maxSpeed);            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            maassa = true;
        }

    }


    void Update()
    {
        hit = damage.hit;

        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        movement = new Vector3(moveX, 0, moveZ);                    //määritykset
        if (movement.magnitude >= 1)
        {
            movement = movement.normalized;                         // estää liian nopean liikkeen kulmittain
        }


        if (jumpDelay <= 0.1)
        {
            jumpDelay = jumpDelay + Time.deltaTime;                 //Varmistaa että hyppäät vain kerran
        }

        if (maassa && Input.GetButtonDown("Jump") && jumpDelay >= 0.1)
        {
            rb.AddForce(new Vector2(0, jumpHight));
            jumpDelay = 0;                                             //Hyppy
        }


        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement, ylös), turnSmooth);
        }                                                              //Käntyminen                                                                               


        float liike = movement.magnitude;
        anim.SetFloat("Speed", liike);                                  //Animaattori   


        if (Input.GetButtonDown("Dodge"))
        {
            dodge = true;
        }

        if (dodge)
        {
            timer = timer + Time.deltaTime;
            if (timer <= dodgetime)
            {
                movement = movement * 2.25f;
            }
            else
            {
                dodge = false;
                timer = 0;
            }
        }
    }

    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            maassa = false;
        }
    }
}

