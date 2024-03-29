using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour {
    
    [SerializeField] Sprite _pressedSprite;
    [SerializeField] UnityEvent _onPressed;
    [SerializeField] UnityEvent _onReleased;
    [SerializeField] int _playerNumber = 1;
        
    Sprite _releasedSprite;
    SpriteRenderer _spriteRenderer;
    

    private void Awake() {

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _releasedSprite = _spriteRenderer.sprite;
    }
    void OnTriggerEnter2D(Collider2D collision) {

        var player = collision.GetComponent<Player>();
        if (player == null || player.PlayerNumber != _playerNumber)
            return;

        BecomePressed();
    }

    private void OnTriggerExit2D(Collider2D collision) {

        var player = collision.GetComponent<Player>();
        if (player == null || player.PlayerNumber != _playerNumber)
            return;

        BecomeReleased();
    }

    private void BecomePressed() {
        _spriteRenderer.sprite = _pressedSprite;
        _onPressed?.Invoke();
    }
    private void BecomeReleased() {

        if (_onReleased.GetPersistentEventCount() == 0)
            return;

        _spriteRenderer.sprite = _releasedSprite;
        _onReleased?.Invoke();
    }
}

