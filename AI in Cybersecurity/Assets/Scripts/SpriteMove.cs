using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMove : MonoBehaviour
{
    float xInput, yInput;
    private float xDiff, yDiff;
    private float oldPosx, oldPosy; //old positions of background to compare to new ones, detecting movement

    Rigidbody2D rb;
    Rigidbody2D target;

    Vector2 targetPos;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Background").GetComponent<Rigidbody2D>();

        //postion of this sprite - position of background
        xDiff = rb.transform.position.x - target.transform.position.x;
        yDiff = rb.transform.position.y - target.transform.position.y;


    }

    // Update is called once per frame
    void Update()
    {
        if (oldPosx != target.transform.position.x || oldPosy != target.transform.position.y)
        {
            rb.transform.position = new Vector2(target.transform.position.x + xDiff, target.transform.position.y + yDiff);
        }
        oldPosx = target.transform.position.x;
        oldPosy = target.transform.position.y;
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        //transform.Translate(-xInput * moveSpeed, -yInput * moveSpeed, 0);
        //if (GetComponent<Rigidbody>().velocity.magnitude > 0)
        //print(target.velocity.magnitude);
        
        //Rigitbody2DForce();        
    }


    void Rigitbody2DForce()
    {
        /*
    if (target.velocity.magnitude > 0)
    {
        rb.velocity = new Vector2(-moveSpeed * xInput, -moveSpeed * yInput);
    }
    else
        rb.velocity = new Vector2(0, 0);
    }
        */
    }
}

