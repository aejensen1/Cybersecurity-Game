using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayGate : MonoBehaviour
{
    public GameObject Gate;
    public Player MyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Gate.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.progression == 5)
        {
            Gate.SetActive(false);
        }
    }
}
