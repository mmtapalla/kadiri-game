using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    //public Text scoreText;
    public InputField usernameText;
    public Text previousScore;
    public InputField searchUserText;

    private System.Random random = new System.Random();

    User user = new User(playerName, playerScore);

    public static int playerScore;
    public static string playerName;

    void Start()
    {
        //playerScore = random.Next(0,101);
        //scoreText.text = "Score: " + playerScore;  
    }

    public void onSubmit()
    {
        //playerScore = GameManager.score;
        playerName = usernameText.text;
        PostToDatabase();
        GameManager.previousPlayer = playerName;
    }

    public void OnGetScore()
    {
        RetrieveFromDatabase();
    }

    public void OnSearchUser()
    {
        SearchFromDatabase();
    }

    public void UpdateScore()
    {
        previousScore.text = user.userName + " Score: " + user.userScore;
    }

    private void PostToDatabase()
    {
        if (playerName != "")
        {
            playerName = playerName.Replace(" ", "-");
            User user = new User(playerName, playerScore); 
            RestClient.Put("https://moneykiss-kadiri-default-rtdb.asia-southeast1.firebasedatabase.app/" + playerName + ".json", user);
        }
    }

    private void RetrieveFromDatabase()
    {
        RestClient.Get<User>("https://moneykiss-kadiri-default-rtdb.asia-southeast1.firebasedatabase.app/" + GameManager.previousPlayer + ".json").Then(response =>
        {
            user = response;
            UpdateScore();
        });
    }

    private void SearchFromDatabase()
    {
        RestClient.Get<User>("https://moneykiss-kadiri-default-rtdb.asia-southeast1.firebasedatabase.app/" + searchUserText.text + ".json").Then(response =>
        {
            user = response;
            UpdateScore();
        });
    }

}
