using UnityEngine;

public class UIStartButton : MonoBehaviour {
          
    public void ClearAllLevelUnlocksAndStartGame() {

        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt($"Level1Unlocked", 1);
    }
}
