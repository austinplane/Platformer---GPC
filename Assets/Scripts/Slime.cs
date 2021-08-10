using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

    [SerializeField] Transform _rightSensor;
    [SerializeField] Transform _leftSensor;
    [SerializeField] Sprite _deadSprite;    

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody;
    Animator _animator;
    Collider2D _collider;
    float _direction = 1;
    

    void Awake() {

        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();        
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

        Vector2 normal = collision.contacts[0].normal;

        if (normal.y <= -0.5)  
            StartCoroutine(Die());

        else 
            player.ResetToStart();   
    }

    IEnumerator Die() {

        _spriteRenderer.sprite = _deadSprite;
        _animator.enabled = false;
        _collider.enabled = false;
        _rigidbody.simulated = false;
        this.enabled = false;


        float alpha = 1;

        while (alpha > 0) {

            yield return null;
            alpha -= Time.deltaTime;
            _spriteRenderer.color = new Color(1, 1, 1, alpha);
        }
    }
}
