using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGate : MonoBehaviour
{
    public GameObject Gate;
    public Player MyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Gate.SetActive(true);
    }

    public void DeactivateGate()
    {
        Gate.SetActive(false);
    }

    public void ActivateGate()
    {
        Gate.SetActive(true);
    }
}
