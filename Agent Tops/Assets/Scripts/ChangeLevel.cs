using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

    bool inTrigger = false;

    public GameObject player;
    private GameObject door;
    private Vector2 newPos;

    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && inTrigger == true)
        {
            Vector2 pos;
            print("inTrigger: x +" + door);
            Target target = (Target)door.GetComponent(typeof(Target));
            pos = target.GetTarget();
            player.GetComponent<Transform>().position = pos;
            print(pos);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Door")
        {
            print("inTrigger: col");
            door = col.gameObject;
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
