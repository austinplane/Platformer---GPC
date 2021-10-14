using System;
using System.Collections;
using UnityEngine;

public class FadingCloud : HittableFromBelow {
    
    SpriteRenderer _spriteRenderer;    
    Collider2D _collider;
    
    [SerializeField] float _resetTime = 5f;

    private void Awake() {

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
    protected override void Use() {

        _spriteRenderer.enabled = false;
        _collider.enabled = false;

        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay() {

        yield return new WaitForSeconds(_resetTime);
        _spriteRenderer.enabled = true;
        _collider.enabled = true;
    }
}
