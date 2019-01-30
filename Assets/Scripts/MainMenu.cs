using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void OnePlayerGame()
    {
        Debug.Log("Loading One Player game");
        SceneManager.LoadScene("OnePlayerGame", LoadSceneMode.Single);
    }

    public void TwoPlayerGame()
    {
        Debug.Log("Loading Two Player game");
        SceneManager.LoadScene("TwoPlayerGame", LoadSceneMode.Single);
    }

    public void GameInfo()
    {
        Debug.Log("Loading How To Play");
        SceneManager.LoadScene("GameInfo", LoadSceneMode.Single);
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to main menu");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit(); // quit game to OS (ignored in Unity Editor)
    }
}