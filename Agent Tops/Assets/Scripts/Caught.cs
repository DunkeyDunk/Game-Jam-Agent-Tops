using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour {

    public UI_Manager UI;
    public bool blink;
    public float blinkTimer = 5f;
    private float timePassed;
    public SpriteRenderer sR;
    public PolygonCollider2D pC;

    private void Update()
    {
        if (blink)
        {
            if (timePassed >= blinkTimer)
            {
                timePassed += Time.deltaTime;
            }
            else
            {
                if (sR.enabled)
                {
                    sR.enabled = false;
                    pC.enabled = false;
                }
                else
                {
                    sR.enabled = true;
                    pC.enabled = true;
                }
                timePassed = 0;
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
        }
    }
}
