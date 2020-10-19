using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton_OnClick()
    {
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

    public void QuitButton_OnClick()
    {
        Application.Quit();
    }
}
