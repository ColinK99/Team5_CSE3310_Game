using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == player.tag)
        {
            VictoryScreen();  
        }
    }

    // Update is called once per frame
    void VictoryScreen()
    {
        SceneManager.LoadScene("VictoryScreen", LoadSceneMode.Single);
    }
}
