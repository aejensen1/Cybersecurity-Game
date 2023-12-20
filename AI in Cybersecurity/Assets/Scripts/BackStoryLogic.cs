using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackStoryLogic : MonoBehaviour
{
    public GameObject BackStory;
    public BackgroundMove MyBackground;
    // Start is called before the first frame update
    void Start()
    {
        BackStory.GetComponent<Canvas>().enabled = true;
        MyBackground.variableMoveSpeed = 0;
        //Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueToGame()
    {
        BackStory.GetComponent<Canvas>().enabled = false;
        //Time.timeScale = 1f;
        Cursor.visible = false;
        MyBackground.variableMoveSpeed = MyBackground.normalMoveSpeed;
        BackStory.SetActive(false);
    }
}
