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

        if (_direction < 0)
            ScanSensor(_leftSensor);
        else if (_direction > 0)
            ScanSensor(_rightSensor);
    }

    private void ScanSensor(Transform _sensor) {
        
        Debug.DrawRay(_sensor.position, Vector2.down * 0.1f, Color.red);

        var result = Physics2D.Raycast(_sensor.position, Vector2.down, 0.1f);
        if (result.collider == null)
            TurnAround();

        Debug.DrawRay(_sensor.position, new Vector2(_direction, 0) * 0.1f, Color.red);

        var _sideResult = Physics2D.Raycast(_sensor.position, new Vector2(_direction, 0), 0.1f);        
        if (_sideResult.collider != null)
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
