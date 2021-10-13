using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    
    Rigidbody2D _rigidbody;
    
    [SerializeField] float _fireballSpeed;

    void Awake() {

        _rigidbody = GetComponent<Rigidbody2D>();
    }


    void Start() {

        _rigidbody.velocity = Vector2.right * _fireballSpeed;
    }

    
    void Update() {
        
    }
}
