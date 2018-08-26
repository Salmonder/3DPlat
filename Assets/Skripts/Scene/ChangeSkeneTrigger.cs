using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSkeneTrigger : MonoBehaviour {

    public string changeTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            SceneManager.LoadScene(changeTo);
        }
    }

}
