using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenario_Breaker : MonoBehaviour
{
    [SerializeField]
    Button BreakerSwitch1;

    [SerializeField]
    Button BreakerSwitch2;

    [SerializeField]
    Button BreakerSwitch3;

    [SerializeField]
    Button BreakerSwitch4;

    [SerializeField] GameObject bg1;
    [SerializeField] GameObject bg2;

    List<Button> switches = new List<Button>();

    int spawn_count;
    // List<float> ycoords = new List<float>();
    // float xcoord = 3.5f;
    // float ycoord;

    bool win_condition = false;
    GameObject[] buttons;
    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        spawn_count = Random.Range(2,4);
        switches.Add(BreakerSwitch1);
        switches.Add(BreakerSwitch2);
        switches.Add(BreakerSwitch3);
        switches.Add(BreakerSwitch4);

        StartCoroutine(WaitCutscene());

        // bg1.SetActive(false);
        // bg2.SetActive(true);
        
        // for (int i = 0; i != spawn_count; i++)
        // {
        //     var swetch = switches[Random.Range(0, switches.Count - 1)];
        //     switches.Remove(swetch);

        //     swetch.gameObject.SetActive(true);
        // }

    }

    // Update is called once per frame
    void Update()
    {
        //CheckWinCondition();

        if (GetWinCondition())
        {
            GameManager gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            gameManager.SetWinCon(true);
        }
    }

    // void Spawning(int count)
    // {
    //     for (int i = 0; i != count; i++)
    //     {
    //         ycoord = ycoords[Random.Range(0, ycoords.Count - 1)];
    //         ycoords.Remove(ycoord);
    //         Instantiate(BreakerSwitch, new Vector3(xcoord, ycoord, 0), Quaternion.identity, this.gameObject.transform.GetChild(0));
    //     }
    // }

    public bool GetWinCondition()
    {
        return win_condition;
    }

    public void CheckWinCondition()
    {
        // spawn_count--;
        // if (spawn_count == 0)
        // {
        //     win_condition = true;
        // }

        // buttons = GameObject.transform.FindGameObjectsWithTag("WinCondition");
        // foreach (GameObject button in buttons)
        // {
        //     button.GetComponents<ButtonScript>();
        // }
        Component[] buttons;
        buttons = FindObjectsOfType<ButtonScript>();
        foreach (ButtonScript button in buttons)
        {
            if (button.pressed == false)
            {
                win_condition = false;
                break;
            }
            win_condition = true;
        }
    }

    IEnumerator WaitCutscene()
    {
        bool cutscenePlaying = true;
        bool buttonsNotInPlay = true;
        while (cutscenePlaying || buttonsNotInPlay)
        {
            if (cutscenePlaying)
            {
                cutscenePlaying = false;
                yield return new WaitForSeconds(1);
            }
            else if (buttonsNotInPlay)
            {
                buttonsNotInPlay = false;

                bg1.SetActive(false);
                bg2.SetActive(true);

                for (int i = 0; i != spawn_count; i++)
                {
                    var swetch = switches[Random.Range(0, switches.Count - 1)];
                    switches.Remove(swetch);

                    swetch.gameObject.SetActive(true);
                }
            }
        }
    }
}
