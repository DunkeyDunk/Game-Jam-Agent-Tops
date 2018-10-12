using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerLaunch : MonoBehaviour {

    public GameObject player;
    public MusicManager MM;
    public float power;
    private bool grounded = true;
    public float minLaunchHight;
    public float maxX;
    public float maxY;
    Vector2 launch;
    public Animator animController;
    public SpriteRenderer spriteRenderer;
    
    // Update is called once per frame
    void Update () {
		if (Input.GetKey(KeyCode.Mouse0) && grounded)
        {
            animController.SetBool("keyDown", true);
            //find spillerens position som vector
            Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y);
            //find musens position vector og minus spillere vectoren
            launch = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) - playerPos;

            print(launch.x.ToString() + "x " + launch.y.ToString() + "y :Before");
            Flip(launch.x);
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
            print(launch.x.ToString() + "x " + launch.y.ToString() + "y :After");

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (launch.y >= minLaunchHight && grounded)
            {
                GetComponent<Rigidbody2D>().velocity += launch * power;
                animController.SetBool("Grounded", false);
                animController.SetBool("keyDown", false);
                grounded = false;
                MM.Landing();
            }
        }


    }
    //checker om man rammer jorden
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            animController.SetBool("Grounded", true);
            //hvis man rammer mister man sin fart
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            grounded = true;
            
        }
    }
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
