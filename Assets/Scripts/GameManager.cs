using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            if (_instance == null)
            {
                Debug.LogError("GameManager not found!");
            }

            return _instance;
        }
    }

    public bool isGameOver;
    public List<GameObject> managers;

    private void Update()
    {
        if (ScoreManager.Instance.CheckScore())
        {
            isGameOver = true;
            SoundManager.Instance.PlayGameOver();
            UIManager.Instance.SetGameOverPanelActive();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
