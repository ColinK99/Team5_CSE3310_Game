using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Game : MonoBehaviour
{
    public GameObject otherButton;
    // Start is called before the first frame update
    public void Resume()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        otherButton.SetActive(true);
    }

    // Update is called once per frame
    public void Pause()
    {
        Time.timeScale = 0f;
        this.gameObject.SetActive(false);
        otherButton.SetActive(true);
    }
}
