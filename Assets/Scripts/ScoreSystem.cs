using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSystem {

    static int _score;
    public static event Action<int> OnScoreChanged;

    public static void AddScore(int points) {

        _score += points;
        OnScoreChanged?.Invoke(_score);
    }
  
}
