using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MackNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mack;
    public Animator animator;
    public Player MyPlayer;


    void Start()
    {
        animator = Mack.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression < 3)
        {
            if (animator.GetBool("MackContact") && Input.GetKeyDown(KeyCode.E))
            {
                Mack.GetComponent<DialogueTrigger>().TriggerDialogue();
                MyPlayer.progression = 2;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) //triggers when player touches something
    {
        if (MyPlayer.progression < 3)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("MackContact", true);
                Debug.Log("touching Mack");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) //triggers when player touches something
    {
        if (MyPlayer.progression < 3)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("MackContact", false);
                Debug.Log("not touching Mack");
            }
        }
    }
}
