using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSystem {

    static int _score;
    
    public static event Action<int> OnHighScoreChanged;
    public static event Action<int> OnScoreChanged;

    public static void AddScore(int points) {

        _score += points;
        OnScoreChanged?.Invoke(_score);
        CheckHighScore();
    }

    private static void CheckHighScore() {

        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (_score > currentHighScore) {
            PlayerPrefs.SetInt("HighScore", _score);
            OnHighScoreChanged?.Invoke(_score);
        }
    }
}
