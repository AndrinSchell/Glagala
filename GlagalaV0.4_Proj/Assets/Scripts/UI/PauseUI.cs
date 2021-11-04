using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    /// <summary>
    /// Pause Menu Object
    /// </summary>
    public GameObject PauseMenu;
    /// <summary>
    /// Options Menu Object
    /// </summary>
    public GameObject OptionsMenu;
    /// <summary>
    /// Click sound clip
    /// </summary>
    public AudioClip ClickSound;
    /// <summary>
    /// Clicksound will be Played from here
    /// </summary>
    public AudioSource audiosrc;
    /// <summary>
    /// If game is pause > true
    /// </summary>
    bool isPaused;
    /// <summary>
    /// Checks for Audio Source and Clip and plays Clip on call
    /// </summary>
    public void Click()
    {
        if (audiosrc && ClickSound != null)
        {
            audiosrc.PlayOneShot(ClickSound);
        }
        else
        {
            Debug.LogWarning("Game Paused -- No Sound");
        }
    }
    /// <summary>
    /// Gets called on input
    /// </summary>
    /// <param name="context"></param>
    public void PauseMenuIP(InputAction.CallbackContext context)
    {
        if (context.performed && !isPaused)
        {
            Pause();
        }
        else if (context.performed && isPaused)
        {
            Resume();
        }
    }
    /// <summary>
    /// Pauses the game and sets Pausemenu Object to Active
    /// </summary>
    public void Pause()
    {
        Click();
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(true);
        }
        Time.timeScale = 0f;
        isPaused = true;
    }
    /// <summary>
    /// Resumes the game and sets Pause Menu to diseabled
    /// </summary>
    public void Resume()
    {
        Click();
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }
        Time.timeScale = 1f;
        isPaused = false;
    }
    /// <summary>
    /// Options menu will be opened from here
    /// </summary>
    public void Options()
    {
        Click();
    }
    /// <summary>
    /// Restarts the Scene
    /// </summary>
    public void Restart()
    {
        Click();
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// Chances Scene to "MainMenu"
    /// </summary>
    public void Menu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
