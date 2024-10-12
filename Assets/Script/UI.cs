using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject gameOverScreen;
    static public bool isPaused;

    public GameObject score;
    public float scoreCount = 0;
    TextMeshProUGUI score_text;

    public GameObject scoreFinal;
    TextMeshProUGUI scoreFinal_text;

    void Start()
    {
        score_text = score.GetComponent<TextMeshProUGUI>();
        scoreFinal_text = scoreFinal.GetComponent<TextMeshProUGUI>();

        isPaused = false;
    }

    void Update()
    {
        score_text.text = scoreCount.ToString();

        if(isPaused && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            RestartScene();
        }
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        score.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreFinal_text.text = scoreCount.ToString();
        isPaused = true;
    }

    public void AddScore()
    {
        scoreCount++;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
