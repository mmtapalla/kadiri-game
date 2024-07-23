using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public bool pressed;
    public Button button;
    public Scenario_Breaker sceneBreaker;

    // Start is called before the first frame update
    void Start()
    {
        // if (button.interactable == false)
        // {
        //     Debug.Log("true");
        //     pressed = true;
        // }
        // else
        // {
        //     Debug.Log("false");
        //     pressed = false;
        // }
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pressed);
    }

    public void Pressed()
    {
        if (pressed == false)
        {
            pressed = true;
            //this.gameObject.SetActive(false);
            button.interactable = false;
        }
        // else if (pressed == true)
        // {
        //     pressed = false;
        // }
        // Debug.Log(pressed);

        sceneBreaker.CheckWinCondition();
        
    }
        // pressed = true;
        // Debug.Log(pressed);
        // this.gameObject.SetActive(pressed);
        // Debug.Log("pain");
        // if (pressed)
        // {
        //     //button.interactable = false;
        //     this.gameObject.SetActive(false);
        //     pressed = false;
        // }
        // else
        // {
        //     //button.interactable = true;
        //     pressed = true;
        // }
}
