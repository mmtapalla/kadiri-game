using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExitScript : MonoBehaviour
{
    public Scenario_FireExit scene;
    public GameObject sign;
    bool signActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        if (GetSignActive())
        {
            scene.FireExitPressed(transform.name);
        }
        else if (GetSignActive() == false)
        {
            scene.WrongExitPressed(transform.name);
        }
    }

    public void SetSignActive(bool state)
    {
        signActive = state;
        Debug.Log(state);
        sign.SetActive(signActive);
    }

    public bool GetSignActive()
    {
        return signActive;
    }
}
