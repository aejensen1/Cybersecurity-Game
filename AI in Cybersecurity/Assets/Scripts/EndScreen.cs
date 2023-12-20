using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public AudioClip OrigTrack;
    public AudioManager SoundManager;

    public GameObject FinalScreen;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        FinalScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEndScreen()
    {
        FinalScreen.SetActive(true);
        if (OrigTrack != null)
        {
            SoundManager.GetComponent<AudioManager>().ChangeBGM(OrigTrack);
        }
        anim.SetTrigger("FadeIn");
        Cursor.visible = true;
        //Time.timeScale = 0f;
    }
}
