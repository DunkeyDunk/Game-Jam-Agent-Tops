using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour {

    public UI_Manager UI;
    public MusicManager MM;
    public bool blink;
    public bool startOff;
    public float blinkTimer = 5f;
    private float timePassed;
    public SpriteRenderer sR;
    public PolygonCollider2D pC;

    private void Start()
    {
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

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("Opdaget - Start");
            UI.Caught();
            MM.Lose();
        }
        else if (col.gameObject.tag ==("Win"))
        {

        }
    }

    void LightOff(Color tmp)
    {
        tmp.a = 0.1f;
        sR.color = tmp;
        pC.enabled = false;
    }

    void LightOn(Color tmp)
    {
        tmp.a = 0.65f;
        sR.color = tmp;
        pC.enabled = true;
    }
}
