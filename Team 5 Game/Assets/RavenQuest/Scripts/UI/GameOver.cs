using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void GameOverMainMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);


    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Scene", LoadSceneMode.Single);
    }

}
