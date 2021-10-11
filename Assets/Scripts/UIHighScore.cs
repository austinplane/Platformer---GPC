using UnityEngine;
using TMPro;

public class UIHighScore : MonoBehaviour {

    TMP_Text _text;

    void Start() {

        _text = GetComponent<TMP_Text>();
        ScoreSystem.OnHighScoreChanged += UpdateScoreText;
        UpdateScoreText(PlayerPrefs.GetInt("HighScore"));
    }

    private void UpdateScoreText(int score) {

        _text.SetText($"High Score: {score}");
    }
}
