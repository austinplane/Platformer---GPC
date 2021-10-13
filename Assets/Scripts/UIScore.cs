using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour {

    TMP_Text _text;

    void Start() {

        _text = GetComponent<TMP_Text>();
        ScoreSystem.OnScoreChanged += UpdateScoreText;
        UpdateScoreText(ScoreSystem.Score);        
    }

    private void UpdateScoreText(int score) {

        _text.SetText($"Score: {score}");
    }

    private void OnDestroy() {

        ScoreSystem.OnScoreChanged -= UpdateScoreText;
    }
}
