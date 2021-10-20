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

    public void ChangeScore()
    {
        UIScoreText.text = "Score: " + ScoreManager.Score.ToString("0");
    }
}
