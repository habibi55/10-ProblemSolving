using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance = null;
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

    private AudioSource soundSource;
    public AudioClip enemyDeath;
    public AudioClip milestonePoint;
    public AudioClip gameOver;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyDeath()
    {
        soundSource.PlayOneShot(enemyDeath);
    }
    
    public void PlayMilestone()
    {
        soundSource.PlayOneShot(milestonePoint);
    }
    
    public void PlayGameOver()
    {
        soundSource.PlayOneShot(gameOver);
    }
}
