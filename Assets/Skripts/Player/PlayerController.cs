using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float moveX;
    float moveY;
    Rigidbody rb;
    public float maxSpeed = 30f;     //liikkumiseen

    bool maassa = false;
    public Transform groundCheck;
    float maanEtäisyys = 1.0f;
    public LayerMask onkoMaata;
    public float jumpHight;         //hyppimiseen
    public float gravityScale = 1.0f;
    public static float globalGravity = -9.81f;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        
    }

    void Update()
    {
        maassa = false;
        Collider[] maa = Physics.OverlapSphere(groundCheck.position, maanEtäisyys, onkoMaata);

        foreach (Collider maata in maa)
        {
            maassa = true;
        }



        if (maassa && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpHight));
        }
    }

    private void LateUpdate()
    {
        rb.velocity = new Vector3(moveX * maxSpeed, rb.velocity.y, moveY * maxSpeed);
    }
}
//https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-character-controllers animaattoriin
