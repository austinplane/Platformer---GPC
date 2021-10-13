using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour {

    [SerializeField] Fireball _fireballPrefab;
    


    void Awake() {
	
    }


    void Start() {

        Instantiate(_fireballPrefab, transform.position, Quaternion.identity);
    }

    
    void Update() {
        
    }
}
