using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenario_Extension : MonoBehaviour
{
    public GameObject ExtARight;
    public GameObject ExtALeft;

    // public Button ALeft;
    // public Button BLeft;
    // public Button ARight;
    // public Button BRight;
    
    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomSpawn()
    {
        var x = Random.Range(0,2);
        
        if (x == 0)
        {
            //gameobject holding the pair of extensions wherein the clean extension (extA) is on the right
            ExtARight.SetActive(true);
            ExtALeft.SetActive(false);
        }
        else if (x == 1)
        {
            //gameobject holding the pair of extensions wherein the clean extension (extA) is on the left
            ExtALeft.SetActive(true);
            ExtARight.SetActive(false);
        }
    }

    //this will be called when the winning button is pressed (the clean extension)
    public void WinCondition()
    {
        StartCoroutine(WaitAnimationWin());
    }

    //this will be called when the losing button is pressed (the cramped extension)
    public void LoseCondition()
    {
        StartCoroutine(WaitAnimationLose());
    }

    IEnumerator WaitAnimationWin()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        gameManager.SetWinCon(true);
    }

    IEnumerator WaitAnimationLose()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        gameManager.SetLoseCon(true);
    }
}
