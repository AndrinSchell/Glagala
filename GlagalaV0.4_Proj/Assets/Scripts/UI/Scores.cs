using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public float _score;
    public float _highScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score.text = mkTime(_score);
        highScore.text = mkTime(PlayerPrefs.GetFloat("HighScore", 0));
    }

    public string mkTime(float t)
    {
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00.0");

        return $"{minutes}.{seconds}";
    }

    public void GoMenu()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

}
