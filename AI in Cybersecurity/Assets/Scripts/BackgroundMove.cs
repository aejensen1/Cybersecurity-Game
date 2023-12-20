using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float normalMoveSpeed; //normal move speed without effects
    public float variableMoveSpeed; //changes (ex. frezzing player)

    float xInput, yInput;

    Vector2 targetPos;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        variableMoveSpeed = normalMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        //transform.Translate(-xInput * moveSpeed, -yInput * moveSpeed, 0);
        Rigitbody2DForce();
    }

    void Rigitbody2DForce()
    {
        rb.velocity = new Vector2(-variableMoveSpeed * xInput, -variableMoveSpeed * yInput);
    }
}

