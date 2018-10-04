using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public UI_Manager UI;
    public GameObject caughtCanvas;
    private void Start()
    {
        caughtCanvas.GetComponent<Canvas>().enabled = false;
    }
    public void CaughtPause()
    {
        {
            print("Opdaget - GM");
            caughtCanvas.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }
    }

    public void RestartLevel()
    {
        print("restart - GM");
        Time.timeScale = 1f;
    }
}
