using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
        // var randX = Random.Range(-210.0f, 210.0f);
        // transform.position = new Vector2(randX, transform.position.y);
        // Debug.Log(transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
