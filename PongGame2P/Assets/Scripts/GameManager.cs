using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score1 = 0; // player 1 (left)
    public int score2 = 0; // player 2 (right)
    public int winningScore = 5;

    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI winText;
    public GameObject ball; // drag Ball here
    private Ball ballScript;

    void Start()
    {
        ballScript = ball.GetComponent<Ball>();
        UpdateScoreUI();
        if (winText) winText.gameObject.SetActive(false);
    }

    public void Player1Scores()
    {
        score1++;
        UpdateScoreUI();
        if (CheckWin()) return;
        ballScript.ResetBall();
    }

    public void Player2Scores()
    {
        score2++;
        UpdateScoreUI();
        if (CheckWin()) return;
        ballScript.ResetBall();
    }

    void UpdateScoreUI()
    {
        if (scoreText1) scoreText1.text = score1.ToString();
        if (scoreText2) scoreText2.text = score2.ToString();
    }

    bool CheckWin()
    {
        if (score1 >= winningScore)
        {
            EndGame(1);
            return true;
        }
        if (score2 >= winningScore)
        {
            EndGame(2);
            return true;
        }
        return false;
    }

    void EndGame(int player)
    {
        Time.timeScale = 0f; // pause
        if (winText)
        {
            winText.gameObject.SetActive(true);
            winText.text = "Player " + player + " Wins!";
        }
    }

    // optional: press R to restart (useful while testing)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        score1 = score2 = 0;
        UpdateScoreUI();
        if (winText) winText.gameObject.SetActive(false);
        ballScript.ResetBall();
    }
}


