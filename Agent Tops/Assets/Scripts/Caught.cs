using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour {

    GameObject[] pausedObj;
    public UI_Manager UI;


    private void Start()
    {
        pausedObj = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("Opdaget - Start");
            UI.Caught();
        }
    }
}
