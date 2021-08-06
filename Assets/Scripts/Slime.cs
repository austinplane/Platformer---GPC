using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

    Rigidbody2D _rigidbody;
    


    void Awake() {

        _rigidbody = GetComponent<Rigidbody2D>();
    }


    void Start() {
        
    }

    
    void Update() {

        _rigidbody.velocity = Vector2.left;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        var player = collision.collider.GetComponent<Player>();
        if (player == null)
            return;

        player.ResetToStart();

    }
}
