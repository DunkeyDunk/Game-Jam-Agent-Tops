using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerLaunch : MonoBehaviour {
    //public references
    public GameObject player;
    public MusicManager MM;
    public Animator animController;
    public SpriteRenderer spriteRenderer;

    //public settings
    public float power;
    public float minLaunchHight;
    public float maxX;
    public float maxY;

    //variables
    Vector2 launch;
    private bool grounded = true;
    private float time;
    
    // Update is called once per frame
    void Update () {
        //check if we are grounded when we try to jump
		if (Input.GetKey(KeyCode.Mouse0) && grounded)
        {
            //play animation
            animController.SetBool("keyDown", true);
            
            //find the players position
            Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y);
            //find the difference vector between the player and the mouse
            launch = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) - playerPos;
            
            //run the flip function
            Flip(launch.x);

            //logic checks for max launch
            if (launch.x > maxX)
            {
                launch.x = maxX;
            }
            if (launch.y > maxY)
            {
                launch.y = maxY;
            }
            if (launch.x < -maxX)
            {
                launch.x = -maxX;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //check if we sould be able to launch
            if (launch.y >= minLaunchHight && grounded)
            {
                //apply our velocity vector
                GetComponent<Rigidbody2D>().velocity += launch * power;
                
                //play animations
                animController.SetBool("Grounded", false);
                animController.SetBool("keyDown", false);
                grounded = false;
                //run the function in MM
                MM.Landing();
            }
        }
        //Safety check if the player is !grounded but on the floor
        //and not being able to jump
        if (time >= 5)
        {
            //after 5 sec you will be able to jump
            grounded = true;
            time = 0;
            //play animation
            animController.SetBool("Grounded", true);
        }
        else if(!grounded)
        {
            time += Time.deltaTime;

        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //checks if you've hit the ground
        if (col.gameObject.tag == "Ground")
        {
            //play animation
            animController.SetBool("Grounded", true);

            //removes any velocity
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            grounded = true;
            
        }
    }
    //flips the player based on launch.x value
    void Flip(float x)
    {
        if (x >= 0) 
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
