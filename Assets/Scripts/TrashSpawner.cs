using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] trashes;
    [SerializeField]
    GameObject parentSpawn;

    private GameObject trash;
    private int interval;
    // Start is called before the first frame update
    void Start()
    {
        interval = 0;
        StartCoroutine(SpawnTrash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTrash()
    {
        while (true)
        {
            trash = trashes[Random.Range(0, trashes.Length)];
            var randX = Random.Range(-8.2f, 8.2f);
            Instantiate(trash, new Vector2(randX, transform.position.y), Quaternion.identity, transform.parent);

            interval += 1;
            if (interval == 5)
            {
                yield return new WaitForSeconds(Random.Range(2, 4));
                interval = 0;
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(1, 3));
            }
            
        }
    }   
}
