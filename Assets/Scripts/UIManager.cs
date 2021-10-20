using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance = null;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }

            if (_instance == null)
            {
                Debug.LogError("UIManager not found!");
            }

            return _instance;
        }
    }
    public Text UIScoreText;
    public Image GameOverPanel;
    public Button MainMenuButton;
    public Button RestartButton;

    private void Start()
    {
        MainMenuButton.onClick.AddListener(() =>
            Debug.Log("Back to the PAST!!"));
        
        RestartButton.onClick.AddListener(() =>
            GameManager.Instance.GameOver());
        
        ChangeScore();
    }

    public void SetGameOverPanelActive()
    {
        GameOverPanel.gameObject.SetActive(true);
    }

    public void ChangeScore()
    {
        UIScoreText.text = "Score: " + ScoreManager.Instance.Score.ToString("0");
    }
}
