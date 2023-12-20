using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public Animator anim1;
    public GameObject PauseInterface;
    public bool GameIsPaused = false;
    //int i = 0; //for counting
    //GameObject AllCreditsText;
    //AllCredits = GameObject.FindGameObjectWithTag("AllCredits").GetComponent<Renderer>();
    // Use this for initialization
    void Start()
    {
        //anim1 = GetComponent<Animator>();
        PauseInterface.GetComponent<Canvas>().enabled = false;
        Cursor.visible = true;
        //AllCredits = GameObject.FindGameObjectWithTag("AllCredits").GetComponent<Renderer>();
        //AllCredits.GetComponent<Renderer>().enabled = false;
        PauseInterface.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                //print("resumed");
            }
            else
            {
                Pause();
                //print("paused");
            }
        }
        */
    }

    /*
            if (i == 0)
        {
            
                PauseInterface.GetComponent<Canvas>().enabled = true;
                //anim1.SetTrigger("StartPause");
                i = 1;
                return;
            }
        }
        
        if (i == 1)
        {
            if (Input.GetKeyDown("escape"))
            {
                PauseInterface.GetComponent<Canvas>().enabled = false;
                //anim1.SetTrigger("StartPause");
                i = 0;
                return;
            }
        }
    }*/
    public void Resume()
    {
        PauseInterface.GetComponent<Canvas>().enabled = false;
        PauseInterface.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.visible = false;
    }

    public void Pause()
    {
        PauseInterface.GetComponent<Canvas>().enabled = true;
        PauseInterface.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.visible = true;
    }

    public void InvisPauseScreen()
    {
        PauseInterface.GetComponent<Canvas>().enabled = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}