using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float scorePoint = 1f;
    private BoxCollider2D enemyCollider;
    private SpriteRenderer enemyRenderer;

    private void Start()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        // tambahkan score
        ScoreManager.Score += scorePoint;
        // ubah text score
        UIManager.Instance.ChangeScore();
        // non aktifkan semua komponen kecuali game object dan script
        ActivateEnemy(false);
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
