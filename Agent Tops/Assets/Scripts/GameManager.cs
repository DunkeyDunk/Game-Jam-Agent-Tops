using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Public variables
    public UI_Manager UI;
    public GameObject caughtCanvas;

    private void Start()
    {
        //run only if we are in the scene "Level 1"
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            //disable the canvas
            caughtCanvas.GetComponent<Canvas>().enabled = false;
        }
    }
    public void CaughtPause()
    {
        {
            //enable the canvas and stop time
            caughtCanvas.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }
    }

    public void RestartLevel()
    {
        //start time again
        Time.timeScale = 1f;
    }
}
