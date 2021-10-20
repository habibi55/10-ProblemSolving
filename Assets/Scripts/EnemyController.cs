using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float _scorePoint = 1f;
    private BoxCollider2D _enemyCollider;
    private SpriteRenderer _enemyRenderer;

    private void Awake()
    {
        _enemyCollider = GetComponent<BoxCollider2D>();
        _enemyRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        // tambahkan score
        ScoreManager.Instance.IncreaseCurrentScore(_scorePoint);
        // ubah ukuran player
        other.GetComponent<PlayerController>().ChangeSize();
        // non aktifkan semua komponen kecuali game object dan script
        ActivateEnemy(false);
        // memainkan audio
        SoundManager.Instance.PlayEnemyDeath();
        // ubah text score
        UIManager.Instance.ChangeScore();
        // jalankan coroutine
        StartCoroutine(DelaySpawn(3f));
    }

    public void ActivateEnemy(bool activate)
    {
        _enemyCollider.enabled = activate;
        _enemyRenderer.enabled = activate;
    }

    private IEnumerator DelaySpawn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        transform.position = SpawnManager.Instance.RandomizePosition();
        ActivateEnemy(true);
    }
}
