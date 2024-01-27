using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject storyScreen;
    public GameObject OptionsMenu;
    public GameObject pauseScreen;

    public void PlayGame()
    {
        SceneManager.LoadScene("Nilla");
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenOptions()
    {
        OptionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        OptionsMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void playStory()
    {
        storyScreen.SetActive(true);
    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

}
