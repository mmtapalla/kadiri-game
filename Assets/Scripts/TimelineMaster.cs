using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineMaster : MonoBehaviour
{
    ListMaster current_timeline;
    

    // Start is called before the first frame update
    // void Awake()
    // {
    //     DontDestroyOnLoad(this.gameObject);
    // }
    
    void Start()
    {
        current_timeline = gameObject.GetComponent<ListMaster>();
        current_timeline.CreateQueue();
    }

    // Update is called once per frame
    void LoadNextScene()
    {
        var next_scene = current_timeline.GetCurrentScene(current_timeline.GetListQueue());
        current_timeline.MoveQueue();
        Instantiate(next_scene, new Vector2(0,0), Quaternion.identity);
        //SceneManager.LoadScene(next_scene);
    }
}
