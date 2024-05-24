using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Explanations
{
    public string[] sentences;
}

[System.Serializable]
public class PhishDialogue
{
    
    public string name;

    //public string questionPrompt;

    [TextArea(3, 10)]
    public string[] sentences;
    public Explanations[] explanations;

}


