using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListMaster : MonoBehaviour
{
    [SerializeField] GameObject SceneA;
    [SerializeField] GameObject SceneB;
    [SerializeField] GameObject SceneC;
    [SerializeField] GameObject SceneD;
    [SerializeField] GameObject SceneE;
    [SerializeField] GameObject SceneF;
    [SerializeField] GameObject SceneG;

    List<GameObject> list_init = new List<GameObject>(); 
    List<GameObject> list_queue = new List<GameObject>();
    List<GameObject> list_waitQueue = new List<GameObject>();
    
    // Start is called before the first frame update
    void Awake()
    {
        list_init.Add(SceneA);
        list_init.Add(SceneB);
        list_init.Add(SceneC);
        list_init.Add(SceneD);
        list_init.Add(SceneE);
        list_init.Add(SceneF);
        list_init.Add(SceneG);
    }

    // Update is called once per frame
    public void CreateQueue()
    {
        if (list_queue.Count != 0)
        {
            list_queue.Clear();
            list_waitQueue.Clear();
            list_init.Add(SceneA);
            list_init.Add(SceneB);
            list_init.Add(SceneC);
            list_init.Add(SceneD);
            list_init.Add(SceneE);
            list_init.Add(SceneF);
            list_init.Add(SceneG);
        }

        for (int i = 0; i < 3; i++)
        {
            var placeholder = GetRandomScene(list_init);
            list_queue.Add(placeholder);
            list_init.Remove(placeholder);
        }

    }

    public void MoveQueue()
    {
        var current_scene = GetCurrentScene(list_queue);
        list_queue.Remove(current_scene);
        list_waitQueue.Add(current_scene);

        var move_scene = GetRandomScene(list_init);
        list_init.Remove(move_scene);
        list_queue.Add(move_scene);

        if (list_init.Count == 2)
        {
            var placeholder = list_waitQueue[0];
            list_waitQueue.Remove(placeholder);
            list_init.Add(placeholder);
        }
    }

    public GameObject GetCurrentScene(List<GameObject> list)
    {
        return list[0];
    }

    public List<GameObject> GetListInit()
    {
        return list_init;
    }

    public List<GameObject> GetListQueue()
    {
        return list_queue;
    }

    public List<GameObject> GetListWait()
    {
        return list_waitQueue;
    }

    public GameObject GetRandomScene(List<GameObject> list)
    {
        var placeholder = list[Random.Range(0, list.Count)];

        return placeholder;

    }

}
