using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelectButton : MonoBehaviour {
    
    [SerializeField] string _levelName;

    public void LoadLevel() {

        SceneManager.LoadScene(_levelName);
    }

    //void OnValidate() {

    //    GetComponentInChildren<TMP_Text>().SetText(_levelName);
    //}
}
