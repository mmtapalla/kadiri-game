using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void stopTime()
    {
        Time.timeScale = 0f;
    }

    public void continueTime()
    {
        Time.timeScale = 1f;
    }
    
    public void btn_change_scene(string scene_name)
    {
        SceneManager.LoadScene(2);
    }
}
