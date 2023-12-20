using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
    //[SerializeField]
    //private InputAction action;

    public BackgroundMove MyBackground;
    public Animator spikatronAnim;

    //public GameObject SpikatronHealthBar;
    public GameObject Spikatron;

    private Animator animator;
    //private bool playerCamera = true;

    public Player MyPlayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /*private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        //spikatronAnim.SetTrigger("SpikatronFloat");
        //action.performed += _ => SwitchState();
        //spikatronAnim.SetTrigger("SpikatronFloat");
    }

    public void SwitchToBoss()
    {
        //spikatronAnim.SetTrigger("SpikatronFloat");
        Debug.Log("Switching Camera to Boss");
        animator.Play("BossCamera");
        MyBackground.variableMoveSpeed = 0;

        //MyPlayer.progression = 13;

        StopAllCoroutines();
        StartCoroutine(WaitxSeconds(4f));

        
        //
        //playerCamera = false;

        /*if (playerCamera)
            {
                animator.Play("BossCamera");
            }
            else
            {
                animator.Play("PlayerCamera");
            }
            playerCamera = !playerCamera;
        */
    }

    
    IEnumerator WaitxSeconds(float seconds)
    {
        Debug.Log("Waiting " + seconds + " seconds");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Done Waiting. No changing camera to Player...");
        animator.Play("PlayerCamera");

        yield return new WaitForSeconds(2);

        MyBackground.variableMoveSpeed = MyBackground.normalMoveSpeed;

        //spikatronAnim.SetTrigger("SpikatronMove");

        //SpikatronHealthBar.GetComponent<HealthManager>().ActivateHealthBar();
        Spikatron.GetComponent<DialogueTrigger>().TriggerDialogue();

    }

}
