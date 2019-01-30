using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public bool pauseEnabled = true;
    private bool waitingToStartGame = true;
    public GameObject ball;
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject commandMessage;
    public GameObject statusMessage;
    string winText;
    private bool waitingForRestart = false;

    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
        playerOne.SetActive(false);
        playerTwo.SetActive(false);
        statusMessage.GetComponent<TextMeshProUGUI>().text = "Welcome to Pong!";
        commandMessage.GetComponent<TextMeshProUGUI>().text = "Press Space to Start";
    }

    // Update is called once per frame
    void Update()
    {
        // Pause / Unpause
        if ((Input.GetKeyDown("p") && (pauseEnabled == true)))
        {
            if (Time.timeScale == 1.0f)
            {
                statusMessage.GetComponent<TextMeshProUGUI>().text = "Paused";
                Time.timeScale = 0.0f;
            }
            else
            {
                statusMessage.GetComponent<TextMeshProUGUI>().text = "";
                Time.timeScale = 1.0f;
            }
        }

        // Only show ball + paddles if waiting and Space Bar pressed
        if (waitingToStartGame && (Input.GetKeyDown(KeyCode.Space)))
        {
            // set the flag to false so that will no longer be checking for input to start game
            waitingToStartGame = false;
            if (ball != null)
            {
                ball.SetActive(true);
                playerOne.SetActive(true);
                playerTwo.SetActive(true);
                commandMessage.GetComponent<TextMeshProUGUI>().text = "";
                statusMessage.GetComponent<TextMeshProUGUI>().text = "";
            }
        }

        // Restart game if waiting for Restart and Space Bar pressed
        if (waitingForRestart && (Input.GetKeyDown(KeyCode.Space)))
        {
            //Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void EndGame()
    {
        // Make game un-pausable
        pauseEnabled = false;

        // Freeze the ball
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        // Hide the players
        playerOne.SetActive(false);
        playerTwo.SetActive(false);

        // Figure out who won
        if (ball.GetComponent<Ball>().p1Score > ball.GetComponent<Ball>().p2Score)
        {
            winText = "Player 1 Wins!";
        }
        else
        {
            winText = "Player 2 Wins!";
        }
        statusMessage.GetComponent<TextMeshProUGUI>().text = winText;

        commandMessage.GetComponent<TextMeshProUGUI>().text = "Press Space for Menu";
        waitingForRestart = true;
    }
}
