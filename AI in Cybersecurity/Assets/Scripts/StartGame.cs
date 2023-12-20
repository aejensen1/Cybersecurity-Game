using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject StartScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartScreen.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame()
    {
        StartScreen.GetComponent<Canvas>().enabled = false;
        StartScreen.SetActive(false);
        Time.timeScale = 1f;
    }

}
