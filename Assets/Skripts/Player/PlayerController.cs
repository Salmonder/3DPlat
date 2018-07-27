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
    bool hit;
    
    



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
            //transform.Translate(new Vector3(movement.x * maxSpeed, 0, movement.z * maxSpeed) * Time.deltaTime, Space.World);
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


        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        movement = new Vector3(moveX, 0, moveZ);
        if (movement.magnitude >= 1)
        {
            movement = movement.normalized;
        }



        if (jumpDelay <= 0.1)
        {
            jumpDelay = jumpDelay + Time.deltaTime;
        }

        if (maassa && Input.GetButtonDown("Jump") && jumpDelay >= 0.1)
        {
            rb.AddForce(new Vector2(0, jumpHight));
            jumpDelay = 0;
        }



        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement, ylös), turnSmooth);
        }



        float liike = movement.magnitude;
        anim.SetFloat("Speed", liike);




        hit = damage.hit;

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            maassa = false;
        }
    }
}

