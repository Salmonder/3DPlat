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
    public Transform groundCheck;
    public float maanEtäisyys = 1.0f;
    public LayerMask onkoMaata;
    public float jumpHight;         
    public float gravityScale = 1.0f;
    public static float globalGravity = -9.81f;
    float jumpDelay = 0;                            //hyppimiseen

    Vector3 ylös = Vector3.up;
    public float turnSmooth;
    Quaternion suunta;
    float viive;                            //kääntyminen

    Animator anim;
    
    



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }




    void FixedUpdate()
    {

        rb.velocity = new Vector3(movement.x * maxSpeed, rb.velocity.y, movement.z * maxSpeed);
    }



    void Update()
    {
        maassa = false;
        Collider[] maa = Physics.OverlapSphere(groundCheck.position, maanEtäisyys, onkoMaata);

        foreach (Collider maata in maa)
        {
            maassa = true;
        }

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

    }
}

