using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour {
    
    [SerializeField] Sprite _buttonDownSprite;
    [SerializeField] UnityEvent _onEnter; 

    void OnTriggerEnter2D(Collider2D collision) {

        var player = collision.GetComponent<Player>();
        if (player == null)
            return;

        var _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _buttonDownSprite;

        _onEnter?.Invoke();
    }
}
