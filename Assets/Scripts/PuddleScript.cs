using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuddleScript : MonoBehaviour
{
    public bool pressed;
    public Button button;
    public Scenario_Puddle scenePuddle;
    public GameObject sign;

    // public float minX;
    // public float maxX;
    // public float ycoord;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        sign.SetActive(false);

        //var randX = Random.Range(0, maxX - minX);
        //var randX = Random.Range(minX, maxX); -
        //var pos = transform.position;
        // Debug.Log(randX); -
        // transform.position = new Vector2(randX, ycoord); -
        //transform.position = new Vector2(randX, pos.y);
        //transform.Translate(randX, 0, 0, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        //GameObject sign = this.gameObject.transform.GetChild(0).gameObject;

        pressed = true;
        button.interactable = false;

        if (sign.activeSelf == false)
        {
            sign.SetActive(true);
        }

        scenePuddle.CheckWinCondition();
        
    }
}
