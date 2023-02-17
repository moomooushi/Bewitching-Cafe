using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("WitchRoom");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void What()
    {
        SceneManager.LoadScene("What");
    }
}
