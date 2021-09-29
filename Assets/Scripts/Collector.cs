using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour {

    [SerializeField] Collectible[] _collectiblesToCollect;
    
    TMP_Text _remainingText;

    void Awake() {
	
    }


    void Start() {
        _remainingText = GetComponentInChildren<TMP_Text>();
    }

    
    void Update() {

        int countRemaining = 0;
        foreach (var collectible in _collectiblesToCollect) {

            if (collectible.isActiveAndEnabled)
                countRemaining++;
        }

        _remainingText?.SetText(countRemaining.ToString());

        if (countRemaining > 0)
            return;

        Debug.Log("Got all Gems.");
    }
}
