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
                                    //nopeus


    Vector3 suunta;
    Vector3 suuntaNorm;
    Vector3 dir;
    Vector3 ylös = Vector3.up;
    public float turnSmooth;        //kääntyminen

    float dist2Player;
    Transform player;
    public float sight = 5;     //etäisyys pelaajaan / Näkökenttä
    

    public int mode;
    // 0 = menee Waypointille 1 = pysähtyy waypointilla 2 = näkee pelaajan 3 = juoksee kohti pelaajaa 4 = knocback
    float noticeTime;
    float wait;
    


    //knockback
    
    Vector3 knockBack;
    int knockForce = 35;
    int upKnock = 10;




    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody> ();
        mode = 0;
    }



    private void FixedUpdate()
    {
        if (mode == 0)
        {
            if (suunta.magnitude >= 0.1)
            {
                rb.velocity = new Vector3(suuntaNorm.x * speed, rb.velocity.y, suuntaNorm.z * speed);       //normi liike
            }
        }

        if (mode == 3)
        {
            if (suunta.magnitude >= 0.1)
            {
                rb.velocity = new Vector3(suuntaNorm.x * chargeSpeed, rb.velocity.y, suuntaNorm.z * chargeSpeed);
            }                                                                                                            
        }                                                                                                   //Liike kun jahtaa pelaajaa
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
            if (mode == 3)
            {
                mode = 0;                                                                               //kadottaa pelaajan
            }
        }
        if (dist2Player <= sight)
        {            
            if (mode == 0)
            {
                mode = 2;                                                                               // Huomaa pelaajan
            }
            dir = player.position - transform.position;
        }                                                                                              // Määritetään Target (pelaaja vai waypoint) 
        
                        

        if (dist <=reachDistance)
        {
            currentPoint++;
            if (mode == 0)
            {
                mode = 1;                                                                               // Pysäyttää waypointille
            }
        }
        if (currentPoint >= path.Length)
        {
            currentPoint = 0;            
        }                                                                                              // Siirtää Waypointin seuraavaan

        
        if (suunta.magnitude >= 0.1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(suunta, ylös), turnSmooth);
        }                                                                                               // Kääntäminen


        //tästä eteenpäin mode säätöä.
        if (mode == 2)
        {
            noticeTime = noticeTime + Time.deltaTime;
            if (noticeTime >= 1)
            {
                noticeTime = 0;
                mode = 3;
            }

        }                                                                                           //vaihtaa hyökkäys modeen
        
        if (mode == 1)
        {
            wait = wait + Time.deltaTime;
            if (wait >= 1)
            {
                wait = 0;
                mode = 0;
            }
        }

        if (mode == 4)
        {
            wait = wait + Time.deltaTime;
            if (wait >= 1)
            {
                wait = 0;
                mode = 3;
            } 
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.tag == "Player")
        {
            mode = 4; 
            knockBack = (transform.position - collision.gameObject.transform.position).normalized * knockForce;
                        
            rb.velocity = Vector3.zero;

            Knock();

        }
    }

    void Knock()
    {
        rb.AddForce(Vector3.up * upKnock + new Vector3(knockBack.x, 0, knockBack.z) * knockForce);
    }

}
