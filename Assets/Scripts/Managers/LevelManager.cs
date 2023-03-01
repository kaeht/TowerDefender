using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int lives = 10;

    public int TotalLives { get; set; }
    public int CurrentWave { get; set; }

    private void Start()
    {
        TotalLives = lives;
        CurrentWave = 1;
    }

    private void ReduceLives(Enemy enemy)
    {
        TotalLives--;
        if (TotalLives <= 0)
        {
            TotalLives = 0;
            GameOver();
        }
    }

    private void GameOver()
    {
        //UIManager.Instance.ShowGameOverPanel();
        //UIManager.Instance.PauseTime();
    }

    private void YouWin()
    {
        //UIManager.Instance.ShowWinPanel();
        //UIManager.Instance.PauseTime();
    }

    private void WaveCompleted()
    {
        CurrentWave++;
        if (CurrentWave == 4)
            YouWin();

        //AchievementManager.Instance.AddProgress("Waves1", 1);
        //AchievementManager.Instance.AddProgress("Waves2", 1);
        //AchievementManager.Instance.AddProgress("Waves3", 1);
    }

    private void OnEnable()
    {
        Enemy.OnEndReached += ReduceLives;
        //Spawner.OnWaveCompleted += WaveCompleted;
    }

    private void OnDisable()
    {
        Enemy.OnEndReached -= ReduceLives;
        //Spawner.OnWaveCompleted -= WaveCompleted;
    }
}
