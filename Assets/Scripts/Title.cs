using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    AudioOptionsManager audio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene(2);
        audio.OnMusicSliderValueChange(1.0f);
        audio.OnSoundEffectsSliderValueChange(1.0f);
    }
}
