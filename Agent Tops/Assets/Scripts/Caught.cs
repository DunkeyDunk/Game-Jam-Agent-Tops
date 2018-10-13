using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour {
    //Public script reference
    public UI_Manager UI;
    public MusicManager MM;
    public SpriteRenderer sR;
    public PolygonCollider2D pC;

    //behavior settings
    public bool blink;
    public bool startOff;
    public float blinkTimer = 5f;
    private float timePassed;
    

    private void Start()
    {
        //turn on and off the light
        //based off the setting
        Color tmp = sR.color;
        if (startOff)
        {
            LightOff(tmp);
        }
        else
        {
            LightOn(tmp);
        }
    }
    private void Update()
    {
        //turn on and off the light at intervels
        if (blink)
        {
            if (timePassed >= blinkTimer)
            {
                Color tmp = sR.color;
                if (pC.enabled)
                {
                    LightOff(tmp);
                }
                else
                {
                    LightOn(tmp);
                }
                timePassed = 0;
            }
            else
            {
                timePassed += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //check if the player is in the trigger
        if (col.gameObject.tag == "Player")
        {
            //run the functions in UI and MM
            UI.Caught();
            MM.Lose();
        }
    }

    //turn off the light
    void LightOff(Color tmp)
    {
        tmp.a = 0.1f;
        sR.color = tmp;
        pC.enabled = false;
    }

    //turn on the light
    void LightOn(Color tmp)
    {
        tmp.a = 0.65f;
        sR.color = tmp;
        pC.enabled = true;
    }
}
