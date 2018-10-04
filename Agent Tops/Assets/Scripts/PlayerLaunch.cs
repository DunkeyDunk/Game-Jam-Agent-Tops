using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaunch : MonoBehaviour {

    public GameObject player;
    public float power;
    private bool grounded;
    public float minLaunchHight;
        
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z) && grounded)
        {
            float i = 0f;
            //find spillerens position som vector
            Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y);
            //find musens position vector og minus spillere vectoren
            Vector2 launch = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) - playerPos;
            launch.Normalize();
            //give spilleren fart
            while (Input.GetKey(KeyCode.Z))
            {
                i = i + Time.deltaTime;
                print(i + " time has passed");
            }
            if (launch.y >= minLaunchHight)
            {
                GetComponent<Rigidbody2D>().velocity += launch * i;
                grounded = false;
            }
        }

        
	}
    //checker om man rammer jorden
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            //hvis man rammer mister man sin fart
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            grounded = true;
        }
    }
}
