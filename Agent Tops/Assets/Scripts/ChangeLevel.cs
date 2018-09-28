using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

    bool inTrigger = false;
    public string scene;


    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && inTrigger == true)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Door")
        {
            inTrigger = true;
        }
	}

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Door")
        {
            inTrigger = false;
        }
    }
}
