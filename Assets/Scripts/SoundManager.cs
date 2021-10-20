using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();
            }

            if (_instance == null)
            {
                Debug.LogError("SoundManager not found!");
            }

            return _instance;
        }
    }

    private AudioSource _soundSource;
    public AudioClip enemyDeath;
    public AudioClip milestonePoint;
    public AudioClip gameOver;

    private void Awake()
    {
        _soundSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyDeath()
    {
        _soundSource.PlayOneShot(enemyDeath);
    }
    
    public void PlayMilestone()
    {
        _soundSource.PlayOneShot(milestonePoint);
    }
    
    public void PlayGameOver()
    {
        _soundSource.PlayOneShot(gameOver);
    }
}
