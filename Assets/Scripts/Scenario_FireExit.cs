using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenario_FireExit : MonoBehaviour
{
    public Button buttonLeft;
    public Button buttonRight;
    public GameObject signLeft;
    public GameObject signRight;

    int x;
    public int exits_to_press;
    public Text floor;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        FireExitRandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextExit()
    {
        buttonLeft.interactable = true;
        buttonRight.interactable = true;
        FireExitRandomSpawn();
    }

    public void FireExitPressed(string side)
    {
        buttonLeft.interactable = false;
        buttonRight.interactable = false;
        StartCoroutine(WaitAnimationNextExit(side));
        
        if (exits_to_press >= 1)
        {
            exits_to_press -= 1;
        }
        else if (exits_to_press <= 1)
        {
            StartCoroutine(WaitAnimationDone(side));
        }
        
    }

    public void WrongExitPressed(string side)
    {
        buttonLeft.interactable = false;
        buttonRight.interactable = false;

        StartCoroutine(WaitAnimationNextExit(side));        
    }

    void FireExitRandomSpawn()
    {
         x = Random.Range(0,2);
            if (x == 1)
            {
                //left
                buttonLeft.gameObject.GetComponent<FireExitScript>().SetSignActive(true);
                buttonRight.gameObject.GetComponent<FireExitScript>().SetSignActive(false);
                // signLeft.SetActive(true);
                // signRight.SetActive(false);
            }
            else
            {
                //right
                buttonLeft.gameObject.GetComponent<FireExitScript>().SetSignActive(false);
                buttonRight.gameObject.GetComponent<FireExitScript>().SetSignActive(true);
                // signRight.SetActive(true);
                // signLeft.SetActive(false);
            }
        floor.text = exits_to_press.ToString();
    }

    IEnumerator WaitAnimationNextExit(string side)
    {
        if (side == "ButtonLeft")
        {
            anim.SetTrigger("ToLeft");
        }
        else if (side == "ButtonRight")
        {
            anim.SetTrigger("ToRight");
        }

        yield return new WaitForSeconds(0.35f);
        NextExit();
    }

    IEnumerator WaitAnimationDone(string side)
    {
        if (side == "ButtonLeft")
        {
            anim.SetTrigger("ToLeft");
        }
        else if (side == "ButtonRight")
        {
            anim.SetTrigger("ToRight");
        }

        yield return new WaitForSeconds(0.37f);

        GameManager gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        gameManager.SetWinCon(true);
    }
}
