using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsCount : MonoBehaviour
{
    public GameObject Hearts;
    public Animator animator;

    public int heartsLeft;
    // Start is called before the first frame update
    void Start()
    {
        Hearts.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("HeartsLeft", heartsLeft);
    }

    public void ShowHearts()
    {
        Hearts.SetActive(true);
    }

    public void HideHearts()
    {
        Hearts.SetActive(false);
    }
}
