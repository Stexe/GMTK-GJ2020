using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject titlePanel;
    public GameObject selectionPanel;
    public GameObject titleBackground;

    public void StartGame()
    {
        titlePanel.SetActive(false);
        selectionPanel.SetActive(false);
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("Game quit!");
        Application.Quit();
    }
}
