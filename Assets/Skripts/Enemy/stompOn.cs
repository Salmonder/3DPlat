using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stompOn : MonoBehaviour
{

    public float stompPower;
    public bool stomped = false;
    float time;
    public float flattenSmooth = 0.5f;
    public float despawn = 10;


    private void OnTriggerEnter(Collider other)
    {
        if (!stomped)
        {
            if (other.gameObject.layer == 11)
            {
                this.transform.parent.gameObject.GetComponent<EnemyPath>().enabled = false;

                stomped = true;
                other.transform.root.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Debug.Log("Stompped");
                other.transform.root.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * stompPower);


            }
        }
    }
    private void Update()
    {
        if (stomped)
        {
            time = time + Time.deltaTime;

            if (transform.parent.localScale.y > 0.25)


            {
                

                transform.parent.localScale += new Vector3(0, -time * flattenSmooth, 0);
                
            }
            transform.parent.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }


        if (time > despawn)
        {
            Destroy(transform.parent.gameObject);
        }



    }
}