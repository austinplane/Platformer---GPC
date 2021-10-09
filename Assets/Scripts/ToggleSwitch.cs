using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleSwitch : MonoBehaviour {

    [SerializeField] UnityEvent _onLeftToggleSwitch;
    [SerializeField] UnityEvent _onRightToggleSwitch;

    [SerializeField] Sprite _leftToggleSwitch;
    [SerializeField] Sprite _rightToggleSwitch;

    SpriteRenderer _spriteRenderer;

    void Start() {

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerExit2D(Collider2D collider) {

        
        var player = collider.GetComponent<Player>();
        if (player == null)
            return;

        
        if (player.GetComponent<Rigidbody2D>().velocity.x > 0) {

            _spriteRenderer.sprite = _rightToggleSwitch;
            _onRightToggleSwitch?.Invoke();
        }
        else {

            _spriteRenderer.sprite = _leftToggleSwitch;
            _onLeftToggleSwitch?.Invoke();
        }
    }
}
