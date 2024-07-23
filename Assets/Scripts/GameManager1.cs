using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public Text timer;

    public int Totaltime = 5;

    int num;

    float startTime;
    float sceneElapsedTime;
    
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    public void Update()
    {
        sceneElapsedTime = Time.time - startTime;
        //since read-only yung Time.time, yung sceneElapsedTime na yung nagrereset ng time kapag nagloload ng bagong scene
        
        if (Totaltime - sceneElapsedTime > 0) {
        
            timer.text = (Totaltime - sceneElapsedTime).ToString("F0");
        } 
        else if (Totaltime - sceneElapsedTime < 0) { //temporary since wala pa tayong gameover state
            //SceneManager.LoadScene(11); 





            //System.Random random = new System.Random();
            //num = random.Next(2,11); //basic randomizer pang load ng ibang scene if naubos yung time (for testing)
            
            
        }
    }
}
