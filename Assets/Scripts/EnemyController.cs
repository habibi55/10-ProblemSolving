using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float scorePoint = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        // tambahkan score
        ScoreManager.Score += scorePoint;
        // ubah text score
        UIManager.Instance.ChangeScore();
        // non aktifkan game object
        gameObject.SetActive(false);
    }
}
