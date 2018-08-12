using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour {

    Damage damage;
    GameObject player;
    int hp;
    public GameObject hp1;
    public GameObject hp2;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        damage = player.GetComponent<Damage>();
        
		
	}
	
	// Update is called once per frame
	void Update () {
        hp = damage.hp;
        if (hp >= 1)
        {
            hp1.SetActive(true);
        }
        else
        {
            hp1.SetActive(false);
        }

        if (hp >= 2)
        {
            hp2.SetActive(true);
        }
        else
        {
            hp2.SetActive(false);
        }



    }
}
