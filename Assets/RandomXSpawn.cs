using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomXSpawn : MonoBehaviour
{

    public float minX;
    public float maxX;
    //public float ycoord;
    float randX;

    void Start()
    {
        var temp = maxX - minX;
        randX = Random.Range(0, temp);
        
        transform.Translate(randX, 0, 0, Space.World);
    }

}
