using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombotNPC : MonoBehaviour
{

    public AudioClip AlarmTrack;
    public AudioManager SoundManager;

    public GameObject Roombot;

    public Animator animator;
    public Animator alarmAnimator;
    public Animator switchAnimator;
    public Player MyPlayer;
    public GameObject PurpleGate;

    // Start is called before the first frame update
    void Start()
    {
        animator = Roombot.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression < 10)
        {
            if (animator.GetBool("RoombotContact") && Input.GetKeyDown(KeyCode.E))
            {
                if(AlarmTrack != null)
                {
                    SoundManager.GetComponent<AudioManager>().ChangeBGM(AlarmTrack);
                }
                Roombot.GetComponent<DialogueTrigger>().TriggerDialogue(1);
                MyPlayer.progression = 10;
                alarmAnimator.SetTrigger("Alarm");
                switchAnimator.SetTrigger("Alarm");
                //animator.SetBool("RoombotContact", false);
            }
        }
        if (MyPlayer.progression == 10)
        {
            if (animator.GetBool("RoombotContact") && Input.GetKeyDown(KeyCode.E))
            {
                Roombot.GetComponent<DialogueTrigger>().TriggerDialogue(1);
                PurpleGate.GetComponent<PurpleGate>().DeactivateGate(); // Open purple gate after dialogue
            }
        }
        else if (MyPlayer.progression == 11)
        {
            if (animator.GetBool("RoombotContact") && Input.GetKeyDown(KeyCode.E))
            {
                Roombot.GetComponent<DialogueTrigger>().TriggerDialogue(2);
                animator.SetBool("RoombotContact", false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) // Triggers when player touches Roombot
    {
        if (MyPlayer.progression < 12)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("RoombotContact", true);
                Debug.Log("touching Roombot");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) // Triggers when player stops touching Roombot
    {
        if (MyPlayer.progression < 12)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("RoombotContact", false);
                Debug.Log("not touching Roombot");
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (MyPlayer.progression < 12)
        {
            if (collision.gameObject.name == "Player")
                animator.SetBool("RoombotContact", true);
        }
    }
}
