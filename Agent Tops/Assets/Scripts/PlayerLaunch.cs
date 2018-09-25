using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaunch : MonoBehaviour {

    public GameObject player;
    public float power;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            //find spillerens position som vector
            Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y);
            //find musens position vector og minus spillere vectoren
            Vector2 launch = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) - playerPos;
            launch.Normalize();
            //give spilleren fart
            GetComponent<Rigidbody2D>().velocity += launch * power;
        }

        
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        print("hit");
        if (col.gameObject.tag == "Ground")
        {
            print("boom");
            GetComponent<Rigidbody2D>().velocity -= GetComponent<Rigidbody2D>().velocity;
        }
    }
}
