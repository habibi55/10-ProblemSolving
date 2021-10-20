using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance = null;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
            }

            if (_instance == null)
            {
                Debug.LogError("ScoreManager not found!");
            }

            return _instance;
        }
    }
    
    public float Score = 0f;
    private float scoreHighlightRange = 10f;
    private float lastScoreHightlight = 0f;

    public void IncreaseCurrentScore(float value)
    {
        Score += value;
        
        if (Score - lastScoreHightlight >= scoreHighlightRange)
        {
            SoundManager.Instance.PlayMilestone();
            lastScoreHightlight += scoreHighlightRange;
        }
    }
}
