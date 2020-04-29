using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Game : MonoBehaviour
{
    public GameObject otherButton;
    public Button jumpButton;
    public Button strikeButton;
    public GameObject move;
    public GameObject quitText;
    // Start is called before the first frame update
    public void Resume()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        jumpButton.enabled = true;
        strikeButton.enabled = true;
        quitText.SetActive(false);
        move.GetComponent<FixedJoystick>().enabled = true;
        otherButton.SetActive(true);
    }

    // Update is called once per frame
    public void Pause()
    {
        Time.timeScale = 0f;
        this.gameObject.SetActive(false);
        jumpButton.enabled = false;
        strikeButton.enabled = false;
        quitText.SetActive(true);
        move.GetComponent<FixedJoystick>().enabled = false;
        otherButton.SetActive(true);
    }

    public void Quit()
    {
        Resume();
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
