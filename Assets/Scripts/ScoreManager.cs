using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
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
    
    public float score;
    private float _scoreHighlightRange = 10f;
    private float _lastScoreHightlight;
    private float _scoreLimit = 100f;

    public void IncreaseCurrentScore(float value)
    {
        score += value;
        
        if (score - _lastScoreHightlight >= _scoreHighlightRange)
        {
            SoundManager.Instance.PlayMilestone();
            _lastScoreHightlight += _scoreHighlightRange;
        }
    }

    public bool CheckScore()
    {
        return score >= _scoreLimit;
    }
}
