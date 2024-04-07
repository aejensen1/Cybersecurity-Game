using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public AudioManager SoundManager;

    public GameObject alarmSwitch;
    public GameObject popUp;
    public GameObject BrownGate;

    public Animator alarmAnimator;
    public Animator switchAnimator;
    //public Animator aiGizmoAnim;

    public Player MyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        alarmAnimator.SetBool("SwitchContact", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression < 11)
        {
            if (switchAnimator.GetBool("SwitchContact") && Input.GetKeyDown(KeyCode.E))
            {
                MyPlayer.progression = 11;
                alarmAnimator.SetTrigger("AlarmOff");
                SoundManager.GetComponent<AudioManager>().StopBGM();
                //aiGizmoAnim.SetTrigger("CloseTerminal");
                switchAnimator.SetBool("SwitchContact", false);
                popUp.GetComponent<MalwareWrong>().AntivirusDisabled();
                BrownGate.GetComponent<BrownGate>().DeactivateGate(); // Open brown gate after dialogue
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) // Triggers when player touches switch
    {
        if (MyPlayer.progression < 11)
        {
            if (other.gameObject.tag == "Player")
            {
                switchAnimator.SetBool("SwitchContact", true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) // Triggers when player touches switch
    {
        if (MyPlayer.progression < 11)
        {
            if (other.gameObject.tag == "Player")
            {
                switchAnimator.SetBool("SwitchContact", false);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (MyPlayer.progression < 11)
        {
            if (collision.gameObject.name == "Player")
                switchAnimator.SetBool("SwitchContact", true);
        }
    }
}
