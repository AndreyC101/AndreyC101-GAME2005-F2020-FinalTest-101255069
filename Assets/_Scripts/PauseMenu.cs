using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Return()
    {
        if (gamePaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            gamePaused = false;
        }
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
}
