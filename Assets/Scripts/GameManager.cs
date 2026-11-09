using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton: von überall erreichbar über GameManager.Instance
    public static GameManager Instance;

    public Transform player;
    public TMP_Text scoreText;
    public float fallDistance = 6f;

    private float score = 0f;
    private bool isGameOver = false;

    public float startSpeed = 1f;
    public float maxSpeed = 3f;
    public float maxSpeedScore = 500f;   // ab diesem Score ist das Spiel maximal schnell

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Update()
    {
    if (isGameOver || Time.timeScale == 0f) return;

    
    score = Mathf.Max(score, player.position.y);
    scoreText.text = Mathf.FloorToInt(score).ToString();

    
    float difficulty = Mathf.Clamp01(score / maxSpeedScore);
    Time.timeScale = Mathf.Lerp(startSpeed, maxSpeed, difficulty);

    // Game Over, wenn der Spieler unter die Kamera fällt
    if (player.position.y < Camera.main.transform.position.y - fallDistance)
    {
        GameOver();
    }
    }

    public void GameOver()
    {
    isGameOver = true;

    Time.timeScale = 1f;

    int finalScore = Mathf.FloorToInt(score);
    int highscore = PlayerPrefs.GetInt("Highscore", 0);

    if (finalScore > highscore)
    {
        PlayerPrefs.SetInt("Highscore", finalScore);  // neuen Rekord speichern
        PlayerPrefs.Save();                           // sofort auf die Festplatte schreiben
    }

    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Damit andere Scripts den Score abfragen können
    public float GetScore()
    {
        return score;
    }
}