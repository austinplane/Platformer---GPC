using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    [SerializeField] Collectible[] _collectiblesToCollect;    


    void Awake() {
	
    }


    void Start() {
        
    }

    
    void Update() {
        
        foreach (var collectible in _collectiblesToCollect) {

            if (collectible.isActiveAndEnabled)
                return;
        }

        Debug.Log("Got all Gems.");
    }
}
