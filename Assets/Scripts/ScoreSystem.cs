using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSystem {

    static int _score;

    public static void AddScore(int points) {

        _score += points;
        Debug.Log($"Score = {_score}");
    }
  
}
