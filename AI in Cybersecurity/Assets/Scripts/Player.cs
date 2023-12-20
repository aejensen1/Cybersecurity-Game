using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip BossTrack;
    public AudioManager SoundManager;

    Rigidbody2D background;
    public PauseMenu PauseInterface;
    public GameObject CinemachineSwitcher;
    public GameObject BrownGate;

    public int progression; //used to indicate progression through each part of the game:
    /*
     * 0 - Start
     * 1 - Keith
     * 2 - Mack
     * 3 - Mower Start
     * 4 - Mower End
     * 5 - AlleyStranger
     * 6 - RobotGuard Start
     * 7 - RobotGuard 2ndDialogue
     * 8 - RobotGuard End
     * 9 - Jerry
     * 10 - Roombot
     * 11 - Spikatron
     */


    float xInput;
    float yInput;
    bool touchingOutpostTile; //for respawns
    bool touchingAntivirus; //for respawns
    bool touchingBossInitiation;

    //for interact prompt
    bool touchingKeith; 

    //Vector2 targetPos;
    //Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sp;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        progression = 0;
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingOutpostTile)
        {
            Debug.Log("Respawning...");
            OutpostRespawn();
        }
        if (touchingAntivirus)
        {
            Debug.Log("Respawning...");
            AntivirusRespawn();
        }
        if (touchingKeith)
        {
            animator.SetBool("KeithContact", true);
            Debug.Log("touching Keith");
        }
        if (touchingBossInitiation) //Start the boss fight
        {
            if (BossTrack != null)
            {
                SoundManager.GetComponent<AudioManager>().ChangeBGM(BossTrack);
            }
            progression = 12;
            BrownGate.GetComponent<BrownGate>().ActivateGate();
            CinemachineSwitcher.GetComponent<CinemachineSwitcher>().SwitchToBoss();
            Debug.Log("touching boss initiation");
            touchingBossInitiation = false;
        }


        //For Pausing
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseInterface.GameIsPaused)
            {
                PauseInterface.GetComponent<PauseMenu>().Resume();
            }
            else
            {
                PauseInterface.GetComponent<PauseMenu>().Pause();
            }
        }



    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        //transform.Translate(-xInput * moveSpeed, -yInput * moveSpeed, 0);
        //Rigitbody2DForce();
        FlipPlayer();
    }

    void FlipPlayer()
    {
        if (xInput > 0.1f)
        {
            sp.flipX = true;
            animator.SetBool("isWalking", true);
        }
        else if (xInput < -0.1f)
        {
            sp.flipX = false;
            animator.SetBool("isWalking", true);
        }
        else if (yInput > 0.1f || yInput < -0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    
    void OnTriggerEnter2D(Collider2D other) //triggers when player touches something
    {
        if (other.tag == "OutpostRespawn")
        {
            touchingOutpostTile = true;
            //print(touchingOutpostTile);
        }
        if (other.tag == "Antivirus" && progression == 10)
        {
            touchingAntivirus = true;
        }
        if (other.tag == "BossInitiation" && progression == 11)
        {
            touchingBossInitiation = true;
        }
        /*
        if (other.tag == "Keith")
        {
            touchingKeith = true;
        }*/
    }

    void OnTriggerExit2D(Collider2D other) //triggers when player touches something
    {
        if (other.tag == "OutpostRespawn")
        {
            touchingOutpostTile = false;
            print(touchingOutpostTile);
        }
        if (other.tag == "Antivirus")
        {
            touchingAntivirus = false;
        }
        if (other.tag == "BossInitiation" && progression == 11)
        {
            touchingBossInitiation = false;
        }
        /*
        if (other.tag == "Keith")
        {
            touchingKeith = false;
            animator.SetBool("KeithContact", false);
            Debug.Log("not touching Keith");
        }*/
    }
    
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.CompareTag("OutpostRespawn"))
        //{
        //    print("respawn");
        //}
        //print("collision detected!");
        //print(collision.gameObject.child.name);
        //Collider2D myCollider = collision.GetContact(0).thisCollider;
        //print(myCollider);
        //print(collision.gameObject.Find("Background Grid/Outpost Respawn"));
        if (collision.gameObject.name == "Outpost Respawn")
            OutpostRespawn();
        if (collision.gameObject.name == "AntivirusObstacles")
            AntivirusRespawn();
    }*/

    void OutpostRespawn()
    {
        background.transform.position = new Vector2(-12.90351f, -2.050911f);
    }

    void AntivirusRespawn()
    {
        background.transform.position = new Vector2(-68.18f, 0f);
    }
    
    
}


