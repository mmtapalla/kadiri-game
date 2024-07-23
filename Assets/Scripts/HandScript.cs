using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CorrectExtension(float posX, float posY)
    {
        transform.position = new Vector2(posX, posY - 1);
        anim.SetTrigger("New Trigger 0");
    }

    public void WrongExtension(float posX, float posY)
    {
        transform.position = new Vector2(posX, posY - 1);
        anim.SetTrigger("New Trigger");
    }
}
