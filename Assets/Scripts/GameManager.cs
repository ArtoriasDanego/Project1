using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton: von überall erreichbar über GameManager.Instance
    public static GameManager Instance;

    public Transform player;
    public TMP_Text scoreText;
    public float fallDistance = 6f;   // wie weit unter der Kamera der Spieler fallen darf

    private float score = 0f;
    private bool isGameOver = false;

    void Awake()
    {
        // Falls es schon einen GameManager gibt: diesen hier löschen
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Update()
    {
        if (isGameOver) return;

        // Score = höchste erreichte Höhe
        score = Mathf.Max(score, player.position.y);
        scoreText.text = Mathf.FloorToInt(score).ToString();

        // Game Over, wenn der Spieler unter die Kamera fällt
        if (player.position.y < Camera.main.transform.position.y - fallDistance)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Damit andere Scripts den Score abfragen können
    public float GetScore()
    {
        return score;
    }
}