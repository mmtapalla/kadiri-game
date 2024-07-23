using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenario_Puddle : MonoBehaviour
{
    [SerializeField]
    GameObject Puddle1;

    [SerializeField]
    GameObject Puddle2;

    [SerializeField]
    GameObject Puddle3;

    [SerializeField]
    GameObject Puddle4;

    List<GameObject> puddles = new List<GameObject>();

    int spawn_count;

    bool win_condition;

    // Start is called before the first frame update
    void Start()
    {
        spawn_count = Random.Range(2,5);
        puddles.Add(Puddle1);
        puddles.Add(Puddle2);
        puddles.Add(Puddle3);
        puddles.Add(Puddle4);

        for (int i = 0; i != spawn_count; i++)
        {
            var puddle = puddles[Random.Range(0, puddles.Count - 1)];
            puddles.Remove(puddle);

            puddle.SetActive(true);
        }

        win_condition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetWinCondition())
        {
            GameManager gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            gameManager.SetWinCon(true);
        }
    }

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
        buttons = FindObjectsOfType<PuddleScript>();
        // int i = 0;
        foreach (PuddleScript button in buttons)
        {
            // i++;
            // Debug.Log(i);
            if (button.pressed == false)
            {
                win_condition = false;
                break;
                
            }
            win_condition = true;
        }
    }
}
