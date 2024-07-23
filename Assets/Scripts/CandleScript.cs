using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CandleScript : MonoBehaviour
{
    float posX;
    float posY;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.position.x);
        // Debug.Log("===");
        // Debug.Log(transform.position.y);
        if (transform.position.x >= 8.6f)
        {
            posX = Mathf.Min(8.6f, transform.position.x);
            transform.position = new Vector2(posX, transform.position.y);
        }
        if (transform.position.x <= -8.6f)
        {
            posX = Mathf.Max(-8.6f, transform.position.x);
            transform.position = new Vector2(posX, transform.position.y);
        }
        if (transform.position.y >= 0.45f)
        {
            posY = Mathf.Min(0.45f, transform.position.y);
            transform.position = new Vector2(transform.position.x, posY);
        }
        if (transform.position.y <= -7.4f)
        {
            posY = Mathf.Max(-7.4f, transform.position.y);
            transform.position = new Vector2(transform.position.x, posY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Trash")
        {
            GameManager gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            gameManager.SetLoseCon(true);
        }
        
        //if collision bounds
    }
}
