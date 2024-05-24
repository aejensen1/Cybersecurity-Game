using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhishDialogueManager : MonoBehaviour
{
    
    public TMP_Text nameText;
    public TMP_Text questionNumberText;
    public TMP_Text dialogueText;

    int slide; //to go through image slides
    //float moveSpeed = 8; //set this to the background move speed.

    public Animator animator;

    public Player MyPlayer;
    public BackgroundMove MyBackground;

    public GameObject Mower;
    public GameObject Hearts;
    public GameObject Malware;
    public HeartsCount heartsCount;
    public MalwareWrong malwareWrong;
    public DialogueManager dialogueManager;

    private Queue<string> questionNumbers;
    private Queue<string> sentences; // for questions
    private Queue<string> explanations; //for explanations

    private bool questionLocked = false; // to check if the question has been answered
    private string currentSentence; // current sentence to be displayed
    private int explanationSlide = 0; // number of slides left for explanation
    public PhishDialogue phishDialogueValue; // to store the phishDialogue value

    /*
     * Answer Key for Phishing Questions
     * 1. n
     * 2. y
     * 3. y
     * 4. n
     * 5. y
     * 6. n
     * 7. n
     * 8. y
     * 9. n
     * 10. y
     * 11. y
     */


    // Start is called before the first frame update
    void Start()
    {
        questionNumbers = new Queue<string>();
        sentences = new Queue<string>();
        explanations = new Queue<string>();
        //snapshots = new Queue<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && !animator.GetBool("Explain")) //If player answers yes...
        {
            questionLocked = false;
            if (animator.GetInteger("Slide") == 1)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 2)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 3)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 4)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 5)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 6)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 7)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 8)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 9)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 10)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 11)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.N) && !animator.GetBool("Explain")) //If player answers no...
        {
            questionLocked = false;
            if (animator.GetInteger("Slide") == 1)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 2)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 3)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 4)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 5)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 6)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 7)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 8)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 9)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 10)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 11)
            {
                heartsCount.heartsLeft--;
                animator.SetBool("Explain", true);
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }         
        }
        //Debug.Log("Explain status: " + animator.GetBool("Explain") + " Explanation Slide: " + explanationSlide);
        else if (animator.GetBool("IsOpen") && Input.GetKeyDown(KeyCode.Space)) // If player answers no and explanation is shown
        {
            if ((!animator.GetBool("Explain") && animator.GetInteger("Slide") >= 1 && animator.GetInteger("Slide") <= 11))
            {
                Debug.Log("Question Locked is true.");
                questionLocked = true;
            }
            else
            {
                Debug.Log("Question Locked is false.");
                questionLocked = false;
            }
            //Debug.Log("Space key pressed for phish dialogue");
            if (dialogueText.text != currentSentence)
            {
                //Debug.Log("Filling in the rest of the sentence...");
                dialogueText.text = "";
                dialogueText.text = currentSentence;
            }
            else if (questionLocked == false)  //&& slide < 15
            {
                //if (!(slide == 11 && explanations.Count == 0))
                //{
                //Debug.Log("Question Locked is false and not explaining. Moving to the next sentence...");
                //PhishDisplayNextSentence();
                //}
                if (dialogueText.text != currentSentence)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log("Filling in the rest of the sentence...");
                        dialogueText.text = "";
                        dialogueText.text = currentSentence;
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (slide == 11 && explanations.Count == 0) // If the quiz is over
                        {
                            MyPlayer.progression = 4;
                            Mower.GetComponent<MowerNPC>().MowerNoInteract();
                            Debug.Log("Space key pressed for post-quiz dialogue. Display next sentence");
                            PhishDisplayNextSentence();
                        }
                        else
                        {
                            Debug.Log("Space key pressed for phish dialogue. Display next sentence");
                            PhishDisplayNextSentence();
                        }
                    }
                }
            }
        }

        if (sentences.Count == 0 && heartsCount.heartsLeft == -1 && slide == -1) //restarting the quiz...
        {
            Debug.Log("Restart Condition Met");
            //EndDialogue();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Mower.GetComponent<PhishDialogueTrigger>().PhishTriggerDialogue();
            }
            //return;
        }

        if (heartsCount.heartsLeft == 0 && slide > 0) //Person has failed the quiz
        {
            heartsCount.heartsLeft--;
            Hearts.GetComponent<HeartsCount>().HideHearts();
            questionNumbers.Clear();
            questionNumbers.Enqueue(" ");
            sentences.Clear();
            sentences.Enqueue("Aww, no wonder we didn't catch the ransomware early. You didn't identify enough emails correctly. Let's try again."); //To restart the quiz
            //sentences.Enqueue();
            slide = -1;
            PhishDisplayNextSentence();
        }
        /*
        if (slide > 11 && MyPlayer.progression < 5) //Post-quiz dialogue
        {
            if (dialogueText.text != currentSentence)

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Filling in the rest of the sentence...");
                    dialogueText.text = "";
                    dialogueText.text = currentSentence;
                }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    MyPlayer.progression = 4;
                    Mower.GetComponent<MowerNPC>().MowerNoInteract();
                    Debug.Log("Space key pressed for post-quiz dialogue. Display next sentence");
                    PhishDisplayNextSentence();
                }
            }
        }   A*/  
    }

    public void StartPhishDialogue (PhishDialogue phishDialogue)
    {
        dialogueManager.PauseDialogue(); // pause the normal dialogue manager
        Debug.Log("PhishDialogueManager is active. Disabling the normal dialogue manager!");
        phishDialogueValue = phishDialogue; // store the phishDialogue value into local variable

        Debug.Log("Begin phishDialogue");
        animator.SetBool("Explain", false);
        animator.SetBool("IsOpen", true);

        MyBackground.variableMoveSpeed = 0;
        Debug.Log("Background speed is set to: " + MyBackground.variableMoveSpeed);

        Hearts.GetComponent<HeartsCount>().ShowHearts();
        heartsCount.heartsLeft = 3; // reset the hearts count to 3

        nameText.text = phishDialogueValue.name;

        questionNumbers.Clear();

        for(int i = 0; i < 11; i++)
        {
            questionNumbers.Enqueue("Question " + (i + 1).ToString() + "/11");
        }

        sentences.Clear();

        foreach (string sentence in phishDialogueValue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    
        slide = 0;

        Debug.Log("PhishDialogueManager is starting. Displaying the first sentence");
        PhishDisplayNextSentence();
    }

    public void PhishDisplayNextSentence()
    { 
        Debug.Log("Sentence Count: " + sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Debug.Log(animator.GetInteger("Slide"));
        string sentence = ""; // value to be displayed from the queue needs to be empty at the start

        if (slide < 15 && !animator.GetBool("Explain")) // Only move forward with the slides if player got answer correct (no explanation needed)
        {
            slide++;
            animator.SetInteger("Slide", slide);

            if (questionNumbers.Count > 0) // questionNumber queue is smaller than sentences so to avoid dequeue error
            {
                string questionNumber = questionNumbers.Dequeue();
                questionNumberText.text = questionNumber;
            }

            sentence = sentences.Dequeue();
            Debug.Log("Sentence dequeued: " + sentence);
            currentSentence = sentence;
        }
        else if (animator.GetBool("Explain")) // If player got answer wrong, show explanation
        {
            if (explanationSlide == 0)
            {
                Hearts.GetComponent<HeartsCount>().HideHearts();
                explanations.Clear();
                Debug.Log("explanations cleared");

                foreach (string explanation in phishDialogueValue.explanations[slide-1].sentences) // store the explanation into the queue
                {
                    explanations.Enqueue(explanation);
                }
                explanationSlide = phishDialogueValue.explanations[slide - 1].sentences.Length; // set the number of slides left for explanation
                Debug.Log("explanation number set to: " + explanationSlide);
            }
            else
            {
                explanationSlide--; // decrement the number of slides left for explanation
                Debug.Log("explanation slide dropped to: " + explanationSlide);
            }

            if (explanations.Count == 0) // if explanation is over
            {
                Debug.Log("explanation is over. Setting explain to false and displaying next sentence");
                explanationSlide = 0;
                animator.SetBool("Explain", false); // end explanation
                //questionLocked = false;
                if (heartsCount.heartsLeft > 0 && slide < 11) // if player has hearts left and quiz is not over
                {
                    Hearts.GetComponent<HeartsCount>().ShowHearts();
                    //PhishDisplayNextSentence(); // move to the next question
                }
                //PhishDisplayNextSentence();
                //return;
                slide++;
                animator.SetInteger("Slide", slide);

                if (questionNumbers.Count > 0) // questionNumber queue is smaller than sentences so to avoid dequeue error
                {
                    string questionNumber = questionNumbers.Dequeue();
                    questionNumberText.text = questionNumber;
                }

                sentence = sentences.Dequeue();
                Debug.Log("Sentence dequeued: " + sentence);
                currentSentence = sentence;
            }
            else
            {
                // Dequeue the next sentence from the queue for the current slide
                sentence = explanations.Dequeue();
                Debug.Log("Explanation dequeued: " + sentence);
                currentSentence = sentence;
            }
        }
        else if (slide >= 12) // quiz is over
        {
            Hearts.GetComponent<HeartsCount>().HideHearts();
            questionNumbers.Clear();
            questionNumbers.Enqueue(" ");
        }
        Debug.Log(slide);

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); // Type out the sentence
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (dialogueText.text == currentSentence)
                break;

            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    void EndDialogue ()
    {
        dialogueManager.ResumeDialogue();
        Debug.Log("PhishDialogueManager is closing. Reenabling the normal dialogue manager!");
        animator.SetInteger("Slide", 0);
        animator.SetBool("IsOpen", false);

        Hearts.GetComponent<HeartsCount>().HideHearts();
        Debug.Log("closing phish dialogue");
        MyBackground.variableMoveSpeed = MyBackground.normalMoveSpeed;
    }
}


