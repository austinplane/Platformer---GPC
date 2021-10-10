using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelectButton : MonoBehaviour {

    [SerializeField] string _levelName;

    public string LevelName => _levelName;

    public void LoadLevel() {

        SceneManager.LoadScene(_levelName);
    }
}
