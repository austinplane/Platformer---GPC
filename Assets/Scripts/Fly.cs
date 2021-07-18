using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {
    
    Vector3 _stortPosition;
    Vector2 _direction = Vector2.up;

    void Awake() {
	
    }


    void Start() {

        _stortPosition = transform.position;
    }

    
    void Update() {

        transform.Translate(_direction * Time.deltaTime);
        var distance = Vector2.Distance(_stortPosition, transform.position);
        
        if (distance >= 2) {
            _direction *= -1;
        }
    }
}
