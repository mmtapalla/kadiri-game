using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class GameManager : MonoBehaviour
{
    ListMaster sceneTimeline;

    public Text timer;

    public int Totaltime;

    int lives;
    public GameObject lifePanel;
    public bool winCon;
    public bool loseCon;
    public GameObject life0;
    public GameObject life1;
    public GameObject life2;
    public GameObject sad0;
    public GameObject sad1;
    public GameObject sad2;

    public Text Score;
    public static int score;
    public static string previousPlayer;

    public GameObject instruction;
    public Text instructionText;

    float startTime;
    float sceneElapsedTime;
    string temp1;
    string temp2;

    public GameObject transition;

    public GameObject GameOver;
    public AudioManager audioManager;
    
    public void Start()
    {
        lives = 3;
        winCon = false;
        loseCon = false;
        LifeUpdate();
        sceneTimeline = gameObject.GetComponent<ListMaster>();
        sceneTimeline.CreateQueue();
        score = 0;
        Score.text = score.ToString();

        StartCoroutine(TransitionScene());
        // startTime = Time.time;
        // LoadNextScene();
    }

    // Update is called once per frame
    public void Update()
    {
        sceneElapsedTime = Time.time - startTime;
        var decimalNumTime = ((Totaltime - sceneElapsedTime) % 1) * 100;
        var wholeNumTime = (Totaltime - sceneElapsedTime) - decimalNumTime/100;
        //since read-only yung Time.time, yung sceneElapsedTime na yung nagrereset ng time kapag nagloload ng bagong scene
        if (Totaltime - sceneElapsedTime > 0) {

            temp2 = $"{decimalNumTime:00}";
            temp1 = $"{wholeNumTime:00}";
            timer.text = "00:00:" + temp1 + ":" + temp2;

        } 
        //if timer reaches zero
        else if (Totaltime - sceneElapsedTime < 0) {
            //if it's these scenarios, a timer reaching zero is a win con
            //Debug.Log(GameObject.FindWithTag("Scenario").name);
            if (GameObject.FindWithTag("Scenario").name == "Scenario_Candle(Clone)" | GameObject.FindWithTag("Scenario").name == "Scenario_Kitchen(Clone)")
            {
                winCon = true;
                loseCon = false;
            }
            else
            {
                winCon = false;
                loseCon = true;
            }
            // LoadNextScene();
            // startTime = Time.time;
        }

        
        if (winCon)
        {
            var factor = Convert.ToInt32(temp1);
            score += 100 + 10 * factor;
            //create function for animation of time adding [maybe coroutine]
            Score.text = score.ToString();
            Destroy(GameObject.FindWithTag("Scenario"));
            StartCoroutine(TransitionScene());
            startTime = Time.time;

            winCon = false;
        }
        else if (loseCon)
        {
            lives -= 1;
            LifeUpdate();
            Score.text = score.ToString();
            Destroy(GameObject.FindWithTag("Scenario"));
            // if lives == 0 (changescene to game over)
            if (lives == 0)
            {
                StartCoroutine(GameOverTransition());
            }
            else if (lives > 0)
            {
                StartCoroutine(TransitionScene());
            }
            startTime = Time.time;
            loseCon = false;
            PlayerScore.playerScore = score;
        }
    }

    void LifeUpdate()
    {
        if (lives == 2)
        {
            sad2.SetActive(true);
            life2.SetActive(false);
        }
        else if (lives == 1)
        {
            sad1.SetActive(true);
            life1.SetActive(false);
        }
        else if (lives == 0)
        {
            sad0.SetActive(true);
            life0.SetActive(false);
        }
        else if (lives == 3)
        {
            life0.SetActive(true);
            life1.SetActive(true);
            life2.SetActive(true);
            sad0.SetActive(false);
            sad1.SetActive(false);
            sad2.SetActive(false);
        }
    }

    public void SetWinCon(bool state)
    {
        winCon = state;
    }
    public void SetLoseCon(bool state)
    {
        loseCon = state;
    }

    public void LoadNextScene()
    {
        var next_scene = sceneTimeline.GetCurrentScene(sceneTimeline.GetListQueue());
        sceneTimeline.MoveQueue();
        Debug.Log(next_scene.name);
        switch (next_scene.name)
        {
            case "Scenario_Breaker 1":
                instructionText.text = "TURN OFF THE BREAKER";
                break;

            case "Scenario_Candle":
                instructionText.text = "AVOID THE TRASH";
                break;

            case "Scenario_Cigarette":
                instructionText.text = "TAP THE CIGARETTE";
                break;

            case "Scenario_Extension":
                instructionText.text = "PLUG IN THE PLUG";
                break;
            
            case "Scenario_FireExit 1":
                instructionText.text = "CLICK THE FIRE EXIT";
                break;

            case "Scenario_Kitchen":
                instructionText.text = "SWIPE TO LOOK AHEAD";
                break;

            case "Scenario_Puddle":
                instructionText.text = "TAP ON THE WET AREAS";
                break;
        }

        Instantiate(next_scene, new Vector2(0,0), Quaternion.identity);
        StartCoroutine(InstructionsPopup());
    }

    public void DebugLoadNextScene()
    {
        Destroy(GameObject.FindWithTag("Scenario"));
        StartCoroutine(TransitionScene());
        // LoadNextScene();
        startTime = Time.time;
    }

    IEnumerator TransitionScene()
    {
        transition.SetActive(true);
        lifePanel.SetActive(true);
        Score.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Score.gameObject.SetActive(false);
        lifePanel.SetActive(false);
        transition.SetActive(false);

        startTime = Time.time;  //resets timer after the transition period
        LoadNextScene();
        // instruction.SetActive(true);
        //instruction.SetActive(false);
    }

    IEnumerator GameOverTransition()
    {
        transition.SetActive(true);
        lifePanel.SetActive(true);
        Score.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Score.gameObject.SetActive(false);
        lifePanel.SetActive(false);
        audioManager.Stop("InGameMusic");
        audioManager.Play("GameOverMusic");
        GameOver.SetActive(true);
    }

    IEnumerator InstructionsPopup()
    {
        instruction.SetActive(false);
        instruction.SetActive(true);
        Button buttAnim = instruction.GetComponent<Button>();
        buttAnim.enabled = true;
        yield return new WaitForSeconds(1);
        buttAnim.enabled = false;
        Animator instAnim = instruction.GetComponent<Animator>();
        instAnim.SetTrigger("exit");
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene(2);
    }


}
