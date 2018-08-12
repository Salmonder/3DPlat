using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour {

    public Transform[] path;
    int reachDistance = 1;
    int currentPoint;                //polulle


    public int speed =4;
    public int chargeSpeed = 6;
    Rigidbody rb;
    float liikeX;
    float liikeZ;                   //nopeus


    Vector3 suunta;
    Vector3 suuntaNorm;
    Vector3 dir;
    Vector3 ylös = Vector3.up;
    public float turnSmooth;        //kääntyminen

    float dist2Player;
    Transform player;
    public float sight = 5;     //etäisyys pelaajaan / Näkökenttä
    

    int moveMode; 
    // 1 = menee Waypointille 2 = pysähtyy waypointilla 3 = näkee pelaajan 4 = juoksee kohti pelaajaa 5 = knocback

   
    


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody> ();                       
    }



    private void FixedUpdate()
    {
        if (suunta.magnitude >= 0.1)
        {
            rb.velocity = new Vector3(suuntaNorm.x * speed, rb.velocity.y, suuntaNorm.z * speed);       //normi liike
        }
    }



    private void Update()
    {
        dist2Player = Vector3.Distance(player.position, transform.position);
        float dist= Vector3.Distance(path [currentPoint].position, transform.position);

        suunta = new Vector3(dir.x, 0, dir.z);
        suuntaNorm = suunta.normalized;                                                                 //Suuntien määritys



        if (dist2Player > sight)
        {            
            dir = path[currentPoint].position - transform.position;            
        }
        if (dist2Player <= sight)
        {            
            dir = player.position - transform.position;
        }                                                                                              // Määritetään Target (pelaaja vai waypoint)              

        

        if (dist <=reachDistance)
        {
            currentPoint++;
        }
        if (currentPoint >= path.Length)
        {
            currentPoint = 0;            
        }                                                                                              // Siirtää Waypointin seuraavaan

        
        if (suunta.magnitude >= 0.1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(suunta, ylös), turnSmooth);
        }                                                                                               // Kääntäminen
    }

}
