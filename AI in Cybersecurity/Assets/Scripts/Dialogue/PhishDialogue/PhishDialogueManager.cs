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

    private Queue<string> questionNumbers;
    private Queue<string> sentences;

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
        //snapshots = new Queue<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) //If player answers yes...
        {
            if (animator.GetInteger("Slide") == 1)
            {
                heartsCount.heartsLeft--;
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
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 7)
            {
                heartsCount.heartsLeft--;
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
        else if (Input.GetKeyDown(KeyCode.N)) //If player answers no...
        {
            if (animator.GetInteger("Slide") == 1)
            {
                PhishDisplayNextSentence();
                Debug.Log("Correct Answer!");
                Malware.GetComponent<MalwareWrong>().CorrectResponse();
            }
            else if (animator.GetInteger("Slide") == 2)
            {
                heartsCount.heartsLeft--;
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 3)
            {
                heartsCount.heartsLeft--;
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
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
            else if (animator.GetInteger("Slide") == 11)
            {
                heartsCount.heartsLeft--;
                PhishDisplayNextSentence();
                Debug.Log("Incorrect Answer!");
                Malware.GetComponent<MalwareWrong>().ActivateMalware();
            }
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

        if (sentences.Count == 0 && heartsCount.heartsLeft == -1) //restarting the quiz...
        {
            Debug.Log("Restart Condition Met");
            //EndDialogue();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Mower.GetComponent<PhishDialogueTrigger>().PhishTriggerDialogue();
            }
            //return;
        }

        if (slide > 11 && MyPlayer.progression < 5) //Post-quiz dialogue
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PhishDisplayNextSentence();
                MyPlayer.progression = 4;
                Mower.GetComponent<MowerNPC>().MowerNoInteract();
            }
        }
        
    }

    public void StartPhishDialogue (PhishDialogue phishDialogue)
    {
        Debug.Log("Begin phishDialogue");
        animator.SetBool("IsOpen", true);

        MyBackground.variableMoveSpeed = 0;
        Debug.Log("Background speed is set to: " + MyBackground.variableMoveSpeed);

        Hearts.GetComponent<HeartsCount>().ShowHearts();
        heartsCount.heartsLeft = 2;

        nameText.text = phishDialogue.name;

        questionNumbers.Clear();

        for(int i = 0; i < 11; i++)
        {
            questionNumbers.Enqueue("Question " + (i + 1).ToString() + "/11");
        }

        sentences.Clear();

        foreach (string sentence in phishDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //for(int i = 0; i < sentences.Count - questionNumbers.Count; i++) 
        //{
        //    questionNumbers.Enqueue("");
        //}
        
        slide = 0;

        PhishDisplayNextSentence();
    }

    public void PhishDisplayNextSentence ()
    {
        Debug.Log("Sentence Count: " + sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Debug.Log(animator.GetInteger("Slide"));

        if (slide < 12)
        {
            slide++;
            animator.SetInteger("Slide", slide);
        }
        Debug.Log(slide);
        if (slide >= 12)
        {
            Hearts.GetComponent<HeartsCount>().HideHearts();
            questionNumbers.Clear();
            questionNumbers.Enqueue(" ");
        }
            

        if(questionNumbers.Count > 0) //questionNumber queue is smaller than sentences so to avoid dequeue error
        {
            string questionNumber = questionNumbers.Dequeue();
            questionNumberText.text = questionNumber;
        }

        string sentence = sentences.Dequeue();

        

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    void EndDialogue ()
    {
        animator.SetBool("IsOpen", false);

        Hearts.GetComponent<HeartsCount>().HideHearts();
        Debug.Log("closing dialogue");
        MyBackground.variableMoveSpeed = MyBackground.normalMoveSpeed;
    }
    
}
