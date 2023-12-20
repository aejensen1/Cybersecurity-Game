using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeithNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Keith;
    public Animator animator;
    public Player MyPlayer;


    void Start()
    {
        animator = Keith.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression < 2)
        {
            if (animator.GetBool("KeithContact") && Input.GetKeyDown(KeyCode.E))
            {
                Keith.GetComponent<DialogueTrigger>().TriggerDialogue();
                MyPlayer.progression = 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) //triggers when player touches something
    {
        if (MyPlayer.progression < 2)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("KeithContact", true);
                Debug.Log("touching Keith");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) //triggers when player touches something
    {
        if (MyPlayer.progression < 2)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("KeithContact", false);
                Debug.Log("not touching Keith");
            }
        }
    }
}
