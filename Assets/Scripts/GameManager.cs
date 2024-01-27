using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public int currentScore;
    public int scorePerNote = 100;

    public TextMeshProUGUI scoreText;

    public NoteScroller NS;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance= this;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            Debug.Log("PAUSE");
            Pause();
        }
    }

    public void Pause()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);
        Time.timeScale = 0;
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        currentScore += scorePerNote;
        scoreText.text = currentScore.ToString();
    }

    public void NoteMiss()
    {
        Debug.Log("MISS");
    }
    
}
