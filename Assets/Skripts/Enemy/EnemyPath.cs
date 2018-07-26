using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour {

    public Transform[] path;
    public float speed;
    public float reachDistance;
    public int currentPoint;

    Vector3 dir;
    Vector3 ylös = Vector3.up;
    public float turnSmooth;

    float dist2Player;
    Transform player;
    public float sight = 5;
    Rigidbody rb;
    Vector3 suunta;
    float liikeX;
    float liikeZ;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody> ();
    }



    private void FixedUpdate()
    {
        rb.velocity = new Vector3(suunta.x * speed, rb.velocity.y, suunta.z * speed);
       
    }



    private void Update()
    {
        dist2Player = Vector3.Distance(player.position, transform.position);
        float dist= Vector3.Distance(path [currentPoint].position, transform.position);

        suunta = new Vector3(dir.x, 0, dir.z);

        if (dist2Player > sight)
        {
            //transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);
            dir = path[currentPoint].position - transform.position;



        }

        if (dist2Player <= sight)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
            dir = player.position - transform.position;
        }

        
        
            suunta = suunta.normalized;
        

        if (dist <=reachDistance)
        {
            currentPoint++;
        }
        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }



        
        if (suunta != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(suunta, ylös), turnSmooth);
        }
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < path.Length; i++)
        {
            if (path.Length > 0)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position, reachDistance);
                }
            }
        }
    }

}
