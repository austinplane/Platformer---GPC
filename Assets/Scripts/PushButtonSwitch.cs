using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour {
    
    [SerializeField] Sprite _pressedSprite;
    [SerializeField] UnityEvent _onPressed;
    [SerializeField] UnityEvent _onReleased;
    
    Sprite _releasedSprite;
    SpriteRenderer _spriteRenderer;

    private void Awake() {

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _releasedSprite = _spriteRenderer.sprite;

        BecomeReleased();
    }
    void OnTriggerEnter2D(Collider2D collision) {

        var player = collision.GetComponent<Player>();
        if (player == null)
            return;

        BecomePressed();
    }

    private void OnTriggerExit2D(Collider2D collision) {

        var player = collision.GetComponent<Player>();
        if (player == null)
            return;

        BecomeReleased();
    }

    private void BecomePressed() {
        _spriteRenderer.sprite = _pressedSprite;
        _onPressed?.Invoke();
    }
    private void BecomeReleased() {
        _spriteRenderer.sprite = _releasedSprite;
        _onReleased?.Invoke();
    }
}

