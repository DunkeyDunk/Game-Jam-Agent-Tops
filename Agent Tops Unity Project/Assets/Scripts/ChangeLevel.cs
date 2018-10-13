using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {
    //codition bools
    bool inTrigger = false;
    bool winReady = false;
    
    //Public variables
    public GameObject player;
    public UI_Manager UI;

    //Private variables
    private GameObject door;
    private Vector2 newPos;
    

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (inTrigger == true)
            {
                Vector2 pos;
                //create a Target reference
                Target target = (Target)door.GetComponent(typeof(Target));
                
                //run the function in the Target script
                pos = target.GetTarget();
                
                //move the player
                player.GetComponent<Transform>().position = pos;
            }

            if (winReady == true)
            {
                UI.End();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        
        //checks the tag on the colided object
        if (col.gameObject.tag == "Door")
        {
            door = col.gameObject;
            inTrigger = true;
        }
        else if (col.gameObject.tag == "Win")
        {
            winReady = true;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //checks the tag on the colided object
        if (col.gameObject.tag == "Door")
        {
            inTrigger = false;
        }
        else if (col.gameObject.tag == "Win")
        {
            winReady = false;
        }
    }
}
