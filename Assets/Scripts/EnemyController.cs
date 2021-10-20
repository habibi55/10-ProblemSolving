using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float scorePoint = 1f;
    private BoxCollider2D enemyCollider;
    private SpriteRenderer enemyRenderer;

    private void Awake()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        // tambahkan score
        ScoreManager.Instance.IncreaseCurrentScore(scorePoint);
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
        enemyCollider.enabled = activate;
        enemyRenderer.enabled = activate;
    }

    private IEnumerator DelaySpawn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        transform.position = SpawnManager.Instance.RandomizePosition();
        ActivateEnemy(true);
    }
}
