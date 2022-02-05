using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMainMenu : MonoBehaviour
{
    public Text bestScoreText;
    public InputField playerNameInput;

    private void Start()
    {
        bestScoreText.text = "Best Score : " + ScoreManager.Instance.CurrentHighscore.playerName + " : " + ScoreManager.Instance.CurrentHighscore.score;
        if(ScoreManager.Instance.CurrentHighscore.playerName.Length > 0)
        {
            playerNameInput.text = ScoreManager.Instance.CurrentHighscore.playerName;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void UpdateName(string newValue)
    {
        ScoreManager.Instance.PlayerName = newValue;
    }
}
