using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public Animator anim;
    public GameObject AllCredits;
    //GameObject AllCreditsText;
    //AllCredits = GameObject.FindGameObjectWithTag("AllCredits").GetComponent<Renderer>();
    // Use this for initialization
    void Start()
    {
        anim = AllCredits.GetComponent<Animator>();
        AllCredits.GetComponent<Canvas>().enabled = false;
        //AllCredits.SetActive(false);
        //AllCredits = GameObject.FindGameObjectWithTag("AllCredits").GetComponent<Renderer>();
        //AllCredits.GetComponent<Renderer>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.L))
        {
            AllCredits.GetComponent<Canvas>().enabled = true;
            //anim.SetTrigger("StartCredits");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            AllCredits.GetComponent<Canvas>().enabled = false;
            //anim.SetTrigger("StartCredits");
        }*/
    }

    public void CreditsBegin()
    {
        Time.timeScale = 1f;
        //AllCredits.SetActive(true);
        AllCredits.GetComponent<Canvas>().enabled = true;
        Debug.Log("Credits Started");
        anim.SetTrigger("StartCredits");
    }

    public void EndGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
