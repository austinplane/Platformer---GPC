using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

    [SerializeField] Transform _rightSensor;
    [SerializeField] Transform _leftSensor;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody;
    float _direction = 1;

    void Awake() {

        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Start() {
        
    }

    
    void Update() {

        _rigidbody.velocity = new Vector2(_direction, _rigidbody.velocity.y);
        Debug.DrawRay(_rightSensor.position, Vector2.down * 0.1f, Color.red);
        
        var result = Physics2D.Raycast(_rightSensor.position, Vector2.down, 0.1f);
        if (result.collider == null)
            TurnAround();
    }

    private void TurnAround() {
        _direction *= -1;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        var player = collision.collider.GetComponent<Player>();
        if (player == null)
            return;

        player.ResetToStart();

    }
}
