using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleSwitch : MonoBehaviour {

    [SerializeField] UnityEvent _onLeftToggleSwitch;
    [SerializeField] UnityEvent _onRightToggleSwitch;
    [SerializeField] UnityEvent _onCenterToggleSwitch;

    [SerializeField] Sprite _leftToggleSwitch;
    [SerializeField] Sprite _rightToggleSwitch;
    [SerializeField] Sprite _centerToggleSwitch;

    SpriteRenderer _spriteRenderer;
    ToggleDirection _currentDirection = ToggleDirection.Center;    

    enum ToggleDirection {

        Left, 
        Center, 
        Right
    }

    void Start() {

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerExit2D(Collider2D collider) {

        
        var player = collider.GetComponent<Player>();
        if (player == null)
            return;
        
        if (player.GetComponent<Rigidbody2D>().velocity.x > 0) 
            _currentDirection = ToggleDirection.Right;        

        else 
            _currentDirection = ToggleDirection.Left;        

        SetToggleDirection(_currentDirection);
    }

    void SetToggleDirection(ToggleDirection _direction) {

        switch (_direction) {

            case ToggleDirection.Left:
                _spriteRenderer.sprite = _leftToggleSwitch;
                _onLeftToggleSwitch?.Invoke();
                break;

            case ToggleDirection.Center:
                _spriteRenderer.sprite = _centerToggleSwitch;
                _onCenterToggleSwitch?.Invoke();
                break;

            case ToggleDirection.Right:
                _spriteRenderer.sprite = _rightToggleSwitch;
                _onRightToggleSwitch?.Invoke();
                break;

            default:
                break;
        }
    }
}
