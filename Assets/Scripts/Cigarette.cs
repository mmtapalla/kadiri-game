using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cigarette : MonoBehaviour
{
    public float minX;
    public float maxX;
    public Button button;
    public Image floating_foot;
    public Image stepped_foot;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GetRandomPosition();
        //Debug.Log(Screen.height);
        
    }

    Vector2 GetRandomPosition(){
        float randomX = Random.Range(minX, maxX);
        return new Vector2(randomX, transform.position.y);
    }

    public void stepped(){
        button.interactable = false;
        floating_foot.enabled = false;
        stepped_foot.transform.position = new Vector2(transform.position.x, transform.position.y + (Screen.height / 3.32f)); //Screen.height for proportion with the current screen size
        StartCoroutine(spriteChanger());

        StartCoroutine(WaitAnimation());
    }

    public IEnumerator spriteChanger(){
        yield return new WaitForSeconds(.5f);
        stepped_foot.transform.position = new Vector2(transform.position.x, transform.position.y + (Screen.height / 1.84f)); //Screen.height for proportion with the current screen size
    }

    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(1);
        GameManager gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        gameManager.SetWinCon(true);
    }
}
