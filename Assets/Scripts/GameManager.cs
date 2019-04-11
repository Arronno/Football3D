using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;

    public GameObject scoreBoard;

    public Text displayScore;

    public Text finalScore;

    public Text bestScore;

    string highScore = "0";

    public void Start()
    {
        highScore = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    public void UpdateBestScore()
    {
        if (FindObjectOfType<BallMovement>().score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", FindObjectOfType<BallMovement>().score);
            highScore = PlayerPrefs.GetInt("BestScore", 0).ToString();
        }
    }

    public void EndGame()
    {
        Invoke("LoadGameOverPanel", 0.2f);
        //Invoke("LoadNewGame", 3f);
    }

    void LoadGameOverPanel()
    {
        scoreBoard.SetActive(false);
        DisplayFinalScore();
        DisplayBestScore();
        gameOver.SetActive(true);
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene("Game");
    }

    void DisplayFinalScore()
    {
        finalScore.text = "Your Score: " + FindObjectOfType<BallMovement>().score.ToString();
    }

    void DisplayBestScore()
    {
        bestScore.text = "Best Score: " + highScore;
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }

    private void Update()
    {
        displayScore.text = "SCORE\n" + FindObjectOfType<BallMovement>().score.ToString();
    }
}
