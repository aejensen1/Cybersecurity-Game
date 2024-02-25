using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    public Animator anim;
    public GameObject ObjectivesText;
    public Player MyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = ObjectivesText.GetComponent<Animator>();
        ObjectivesText.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("isHidden") == true)
        {
            ObjectivesText.GetComponent<Canvas>().enabled = false;
        }
        else if(anim.GetBool("newObjective") == false)
        {
            ObjectivesText.GetComponent<Canvas>().enabled = true;
            anim.SetInteger("objectiveNum", MyPlayer.progression);
        }
        

    }

    public void setNewObjective(bool enabled)
    {
        anim.SetBool("newObjective", enabled);
        anim.SetBool("isHidden", false);
    }
}
