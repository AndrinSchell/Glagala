using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinMenuUI : MonoBehaviour
{
    /// <summary>
    /// Audioclip for Buttons
    /// </summary>
    public AudioClip ClickSound;
    /// <summary>
    /// Audio will be Played from here
    /// </summary>
    public AudioSource audiosrc;
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
    /// Quits the Application
    /// </summary>
    public void Quit()
    {
        Click();
        Application.Quit();
    }
    /// <summary>
    /// Starts level with Tag "Proto"
    /// </summary>
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Proto");
    }
}
