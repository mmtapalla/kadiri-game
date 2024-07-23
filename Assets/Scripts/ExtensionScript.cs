using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionScript : MonoBehaviour
{ 
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("this ran");
        Debug.Log(hand.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("hash");
    }

    public void ChangeHandPosition()
    {
        //Vector2 newPosition = Camera.main.ScreenToWorldPoint(transform.position);
        //hand.transform.position = new Vector2(newPosition.x, newPosition.y);
        hand.transform.SetAsLastSibling();
        hand.transform.position = new Vector2(transform.position.x, transform.position.y - 100);
    }
}
