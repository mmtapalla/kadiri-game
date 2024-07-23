using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    public float wait_time = 10f;


    void Start()
    {
        StartCoroutine(Splash_duration());
    }

    IEnumerator Splash_duration()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(1);
    }

}
