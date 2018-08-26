using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour {

    Vector3 knockBack;
    public float KnockForce = 10;
    public float knockTime = 0.25f;
    public bool hit = false;
    float time = 0;
    Rigidbody rb;
    public float upKnock = 10;              //knock


    public int hp;
    public GameObject mesh;
    PlayerController con;


    bool invinci = false;
    public float invinciTime = 1;
    public GameObject Coll;
    float timer;                            //invinciframes

    
    public int lives;
        

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = 2;
        con = GetComponent<PlayerController>();
        lives = PlayerPrefs.GetInt("lives");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!invinci)
        {
            if (collision.collider.tag == "Enemy")
            {
                //Debug.Log("Took damage");

                knockBack = (transform.position - collision.gameObject.transform.position).normalized * KnockForce;

                hit = true;

                rb.velocity = Vector3.zero;

                Knock();
                if (hp >= 1)
                {
                    hp = hp - 1;
                }
                invinci = true;
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

        if (invinci)
        {
            timer = timer + Time.deltaTime;
            if (timer >= invinciTime)
            {
                invinci = false;
                Coll.SetActive(false);
                Coll.SetActive(true);
            }
        }
        else
        {
            timer = 0;
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

        if (lives >= 1)
        {
            lives = lives - 1;
            PlayerPrefs.SetInt("lives", lives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }


}
