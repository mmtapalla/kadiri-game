using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMg : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;

    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            if (SceneManager.GetActiveScene ().buildIndex != 1) {
                SceneManager.LoadScene (1);
            } else {
                if (exitPanel) {
                    exitPanel.SetActive (true);
                }
            }
        }
    }

    public void onUserClickYesNo (int choice)
    {
        if (choice == 1) {
            Application.Quit ();
        }
        exitPanel.SetActive (false);
    }

    public void onUserClickStart ()
    {
        SceneManager.LoadScene(1);
    }
}
