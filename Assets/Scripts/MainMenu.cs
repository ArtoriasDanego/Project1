using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public string gameSceneName = "Main";
    public TMP_Text highscoreText;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Highscore: " + highscore;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");   // Im Editor passiert sonst nichts sichtbar
        Application.Quit();  // Beendet das Spiel im fertigen Build
    }
}