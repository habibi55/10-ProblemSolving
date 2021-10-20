using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

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
    public Text uiScoreText;
    public Image gameOverPanel;
    public Button mainMenuButton;
    public Button restartButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(() =>
            Debug.Log("Back to the PAST!!"));
        
        restartButton.onClick.AddListener(() =>
            GameManager.Instance.GameOver());
        
        ChangeScore();
    }

    public void SetGameOverPanelActive()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    public void ChangeScore()
    {
        uiScoreText.text = "Score: " + ScoreManager.Instance.score.ToString("0");
    }
}
