using System;
using System.Collections;
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

    private float scoreLimit = 100f;
    public bool isGameOver = false;

    private void Update()
    {
        if (ScoreManager.Instance.Score >= scoreLimit)
        {
            isGameOver = true;
            SoundManager.Instance.PlayGameOver();
            UIManager.Instance.SetGameOverPanelActive();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            
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
