using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float startTime;
    private bool finnished = false;
    public GameObject endScreen;
    public int Bonus;
    public float t;

    public string timerfinn;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        Bonus = 10;
        endScreen.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        if (finnished)
        {
            return;
        }

        t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00.0");

        text.text = $"{minutes}.{seconds}";

        timerfinn = text.text;

        if (minutes == "01")
        {
            Bonus = 5;
            text.color = Color.red;
        }
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
    public void Finnish()
    {
        endScreen.GetComponent<Scores>()._score = t;
        finnished = true;
        Time.timeScale = 0f;
        if (PlayerPrefs.GetFloat("HighScore", 0) == 0)
        {
            PlayerPrefs.SetFloat("HighScore", t);
        }
            if (PlayerPrefs.GetFloat("HighScore", 0) > t)
            {
                PlayerPrefs.SetFloat("HighScore", t);
                endScreen.GetComponent<Scores>()._highScore = t;
            }
        endScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Finnish();
            finnished = true;
        }
    }
}
