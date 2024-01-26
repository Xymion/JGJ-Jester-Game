using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Nilla");
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
