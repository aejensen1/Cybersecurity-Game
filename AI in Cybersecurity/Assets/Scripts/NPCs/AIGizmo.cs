using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGizmo : MonoBehaviour
{
    public GameObject PocketAI;
    public GameObject AntivirusDetector;
    public Animator animator;
    public Player MyPlayer;
    public BackgroundMove MyBackground;


    bool activeStatus;

    // Start is called before the first frame update
    void Start()
    {
        PocketAI.GetComponent<Canvas>().enabled = false;
        animator.SetInteger("BodySlide", 0);
        HideAll();
        activeStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeStatus)
        {
            if (MyPlayer.progression == 11)
            {
                AntivirusDetector.GetComponent<AntivirusDetector>().DeactivateDetector();
                CloseInteractables();
            }

            if (Input.GetKeyDown("1"))
            {
                if(MyPlayer.progression < 10)
                {
                    if (animator.GetBool("TerminalOpen") == true)
                        ShowPocketAI();
                    else
                        TerminalIdle();
                }
                else if(MyPlayer.progression == 10)
                {
                    if (animator.GetBool("HideAll") == false)
                    {
                        AntivirusDetector.GetComponent<AntivirusDetector>().ActivateDetector();
                        Debug.Log("Ai Gizmo Hidden");
                        HideAll();
                    }
                    else if (animator.GetBool("HideAll") == true)
                    {
                        AntivirusDetector.GetComponent<AntivirusDetector>().DeactivateDetector();
                        Debug.Log("Ai Gizmo Visible");
                        CloseInteractables();
                    }
                }
                else if(MyPlayer.progression == 13)
                {
                    PocketAI.GetComponent<DialogueTrigger>().TriggerDialogue(1);
                }
            }

            if (Input.GetKeyDown("y"))
            {
                if (animator.GetInteger("BodySlide") == 0)
                {
                    if (MyPlayer.progression == 6)
                        animator.SetInteger("BodySlide", 1);
                    else
                        animator.SetTrigger("FailedSearch");
                }
                else if (animator.GetInteger("BodySlide") == 1)
                    animator.SetInteger("BodySlide", 2);
                else if (animator.GetInteger("BodySlide") == 2)
                {
                    animator.SetInteger("BodySlide", 3);
                    MyPlayer.progression = 7;
                }
                    
            }
        }
    }

    public void ShowPocketAI()
    {
        activeStatus = true;
        PocketAI.GetComponent<Canvas>().enabled = true;
        CloseInteractables();
        if (animator.GetInteger("BodySlide") != 3) // Make it so that after a successful hack, the terminal does not reset
        {
            animator.SetInteger("BodySlide", 0);
        }
        MyBackground.variableMoveSpeed = MyBackground.normalMoveSpeed;
        Debug.Log("PocketAI triggered");
    }

    void TerminalIdle()
    {
        animator.SetBool("TerminalOpen", true);
        animator.SetBool("HideAll", false);
        MyBackground.variableMoveSpeed = 0;
    }

    void CloseInteractables()
    {
        animator.SetBool("TerminalOpen", false);
        animator.SetBool("HideAll", false);
    }

    void HideAll()
    {
        animator.SetBool("TerminalOpen", false);
        animator.SetBool("HideAll", true);
    }
}
