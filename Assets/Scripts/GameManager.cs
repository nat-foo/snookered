using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI countText;
    public GameObject victoryTextObject;
    public GameObject defeatTextObject;
    public int totalBalls;
    private int ballCount = 0;
    public float victoryTimer = 3f;
    public float defeatTimer = 1f;
    private float timerCurrent = 0;
    private bool gameOver = false;

    void Start()
    {
        countText.text = $"{ballCount} / {totalBalls}";
        victoryTextObject.SetActive(false);
        defeatTextObject.SetActive(false);
        timerCurrent = victoryTimer;
    }
    void Update()
    {
        if (gameOver)
        {
            Debug.Log($"Timer until gameover: {timerCurrent}");
            if (timerCurrent <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            timerCurrent -= Time.deltaTime;
        }
    }
    public void ScorePoint()
    {
        ballCount++;
        if (ballCount >= totalBalls)
        {
            countText.text = "Sink the 8-Ball to win!";
        }
        else
        {
            countText.text = $"{ballCount} / {totalBalls}";
        }
    }
    public void ScoreBall8()
    {
        if (ballCount >= totalBalls)
        {
            // Sunk the 8 ball last.
            victoryTextObject.SetActive(true);
            timerCurrent = victoryTimer;
            gameOver = true;
        }
        else
        {
            // Sunk the 8 ball before sinking all the others.
            defeatTextObject.SetActive(true);
            timerCurrent = defeatTimer;
            gameOver = true;
        }
    }
    public void GameOver()
    {
        if (!gameOver)
        {
            defeatTextObject.SetActive(true);
            timerCurrent = defeatTimer;
            gameOver = true;
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}