using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Debug.Log("PAUSE");
            Pause();
    }

    public void Pause()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);
        Time.timeScale = 0;
    }
}
