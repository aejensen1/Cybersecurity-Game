using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator animator;
    public Animator robotGuardAnim;
    public Animator healthAnim;

    public GameObject Mower;
    public GameObject AIGizmo;
    public GameObject HealthManager;
    public GameObject Spikatron;
    public GameObject FinalScreen;

    public BackgroundMove MyBackground;
    public Player MyPlayer;
    public HealthManager SpikatronHealth;

    private Queue<string> sentences;
    string currentSentence;

    int slide;

    //float moveSpeed = 8; //set this to the background move speed.


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        //For skipping the text delay
        if (dialogueText.text == currentSentence)
        {
            if (MyPlayer.progression != 14)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    DisplayNextSentence();
                }
            }
            else //Final Boss Question calls Spikatron health functions
            {
                if (Input.GetKeyDown(KeyCode.Y)) //If player enters Yes
                {
                    Debug.Log("Question: " + slide);
                    if (slide == 0)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 1)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 2)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 3)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 4)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 5)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 6)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 7)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 8)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 9)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 10)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 11)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 12)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 13)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 14)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 15)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 16)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 17)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 18)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 19)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 20)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 21)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 22)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 23)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 24)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 25)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 26)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 27)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 28)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 29)
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    DisplayNextSentence();
                }
                else if (Input.GetKeyDown(KeyCode.N)) //If Player enters no
                {
                    Debug.Log("Question: " + slide);
                    if (slide == 0)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 1)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 2)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 3)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 4)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 5)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 6)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 7)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 8)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 9)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 10)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 11)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 12)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 13)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 14)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 15)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 16)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 17)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 18)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 19)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 20)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 21)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 22)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 23)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 24)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 25)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 26)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    else if (slide == 27)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 28)//
                    {
                        HealthManager.GetComponent<HealthManager>().TakeDamage(5f);
                        Debug.Log("Correct Answer!");
                    }
                    else if (slide == 29)
                    {
                        HealthManager.GetComponent<HealthManager>().Heal(5f);
                        Debug.Log("Incorrect Answer!");
                    }
                    DisplayNextSentence();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialogueText.text = "";
                dialogueText.text = currentSentence;
            }
        }
        

    }

    public void StartDialogue (Dialogue dialogue)
    {
        slide = -1;

        Debug.Log("Begin dialogue with " + dialogue.name);
        animator.SetBool("IsOpen", true);

        MyBackground.variableMoveSpeed = 0;
        Debug.Log("Background speed is set to: " + MyBackground.variableMoveSpeed);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            Debug.Log("Queueing " + sentence);
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if(sentences.Count == 0  || (MyPlayer.progression < 15 && SpikatronHealth.healthAmount <= 0f))
        {
            EndDialogue();
            return;
        }

        currentSentence = sentences.Dequeue();
        slide++; //Current Question number in boss fight

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
        Debug.Log(currentSentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (dialogueText.text == currentSentence)
                break;

            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void EndDialogue ()
    {
        MyBackground.variableMoveSpeed = MyBackground.normalMoveSpeed;
        animator.SetBool("IsOpen", false);
        Debug.Log("closing dialogue");

        if (nameText.text == "Amy") //Finishes normal dialogue. Start Phish Dialogue/quiz
        {
            nameText.text = "";
            Mower.GetComponent<PhishDialogueTrigger>().PhishTriggerDialogue();
        }
            
        if (nameText.text == "Alley Stranger") //First time getting the AI Gizmo / Pocket AI
            AIGizmo.GetComponent<AIGizmo>().ShowPocketAI();
        if (nameText.text == "Robot Guard" && MyPlayer.progression < 6) //Finished first dialogue with Robot Guard. Moving on to second dialogue.
        {
            nameText.text = "";
            MyPlayer.progression = 6;
        }
        else if (nameText.text == "Robot Guard" && MyPlayer.progression < 8) //Done disabling the Robot Guard
        {
            robotGuardAnim.SetTrigger("ShutDown");
            MyPlayer.progression = 8;
        }
        else if (nameText.text == "Spikatron" && MyPlayer.progression < 13) //Done introducing Spikatron. Now prompting health bar to show.
        {
            HealthManager.GetComponent<HealthManager>().ActivateHealthBar();
            MyPlayer.progression = 13;
        }
        else if (nameText.text == "AI Gizmo" && MyPlayer.progression < 15 && SpikatronHealth.healthAmount <= 0f) //Player has beaten Spikatron. Trigger final dialogue
        {
            MyPlayer.progression = 15;
            healthAnim.SetTrigger("OffScreen");
            Spikatron.GetComponent<DialogueTrigger>().TriggerDialogue(2);
        }
        else if (nameText.text == "AI Gizmo" && MyPlayer.progression < 15) //Begin final boss questions
        {
            MyPlayer.progression = 14;
            AIGizmo.GetComponent<DialogueTrigger>().TriggerDialogue(2);
        }
        else if (nameText.text == "Spikatron" && MyPlayer.progression < 16) //Done introducing Spikatron. Now prompting health bar to show.
        {
            MyPlayer.progression = 16;
            FinalScreen.GetComponent<EndScreen>().ShowEndScreen();
        }

        //nameText.text = ""; //Clear name text
    }
}
