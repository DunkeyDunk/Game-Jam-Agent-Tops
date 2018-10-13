using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    //GameManager reference
    public GameManager GM;

    public void Caught()
    {
        //run the function in GM
        GM.CaughtPause();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //run the function in GM
        GM.RestartLevel();
    }

    public void Exit()
    {
        //close the game
        Application.Quit();
    }

    public void LoadLevel()
    {
        //load level 1
        SceneManager.LoadScene(1);
    }

    public void End()
    {
        //load the ending
        SceneManager.LoadScene(2);
    }
}
