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



    private void Start()
    {
        
    }

    private void Update()
    {
        
        float dist= Vector3.Distance(path [currentPoint].position, transform.position);


        transform.position = Vector3.MoveTowards (transform.position, path[currentPoint].position, Time.deltaTime * speed);
        
        if (dist <=reachDistance)
        {
            currentPoint++;
        }
        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }



        dir = path[currentPoint].position - transform.position;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir, ylös), turnSmooth);
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
