using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario_Kitchen : MonoBehaviour
{
    public Animator animMid;

    //public GameObject chefMid;

    private float timeNotMid;
    //placeholder muna to for the static timer
    private float timer;

    //SwipeInput SwipeInput;
    // Start is called before the first frame update
    void Start()
    {
        timer = 10;
        StartCoroutine(DistractChef());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SwipeInput.swipedLeft)
        {
            if (animMid.GetCurrentAnimatorStateInfo(0).IsName("mid"))
            {
                animMid.SetTrigger("swipeLeft");
            }
            if (animMid.GetCurrentAnimatorStateInfo(0).IsName("right"))
            {
                timeNotMid -= .5f;
                animMid.SetTrigger("swipeLeft");
            }
            //chefMid.SetActive(false);
        }
        if (SwipeInput.swipedRight)
        {
            //Debug.Log("swiped right");
            if (animMid.GetCurrentAnimatorStateInfo(0).IsName("left"))
            {
                timeNotMid -= .5f;
                animMid.SetTrigger("swipeRight");
            }
            if (animMid.GetCurrentAnimatorStateInfo(0).IsName("mid"))
            {
                animMid.SetTrigger("swipeRight");
            }
        }

        if (animMid.GetCurrentAnimatorStateInfo(0).IsName("left") || animMid.GetCurrentAnimatorStateInfo(0).IsName("right") )
        {

            timeNotMid += Time.deltaTime;
            var stringTime = $"{timeNotMid:00}";
            Debug.Log(stringTime);
        }

        //losecon
        if (timeNotMid > Mathf.Max( 6, (float)timer * (2/3) ))
        {
            GameManager gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            gameManager.SetLoseCon(true);
        }
    }

    IEnumerator DistractChef()
    {
        var factor = 3;
        while (true)
        {

            if (animMid.GetCurrentAnimatorStateInfo(0).IsName("mid"))
            {
                if (timeNotMid < 2)
                {
                    factor = 2;
                }
                var proba = Random.Range(0,factor);
                if (proba == 1)
                {
                    proba = Random.Range(0,2);
                    if (proba == 1)
                    {
                        animMid.SetTrigger("swipeRight");
                    }
                    else
                    {
                        animMid.SetTrigger("swipeLeft");
                    }
                }
            }
            yield return new WaitForSeconds(0.4f);
        }
    }
}
