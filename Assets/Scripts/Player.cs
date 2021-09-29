using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] int _playerNumber = 1;
    [Header("Movement")]
    [SerializeField] float _speed = 1;
    [SerializeField] float _slipFactor = 1;
    [Header("Jump")]
    [SerializeField] float _jumpVelocity = 10;
    [SerializeField] int _maxJumps = 2;
    [SerializeField] float _downPull = 5;
    [SerializeField] float maxJumpDuration = 0.3f;
    [Header("Collision")]
    [SerializeField] Transform _feet;

    float _fallTimer;
    Vector2 _startPosition;
    int _jumpsRemaining;
    float _jumpTimer;
    Rigidbody2D _rigidbody2D;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    float _horizontal;
    Collider2D hit;
    bool _isGrounded;
    bool isOnIce;
    

    public int PlayerNumber => _playerNumber;
    private string _jumpButton;
    private string _horizontalAxis;
    int _defaultLayerMask;

    private void Start() {

        _startPosition = transform.position;
        _jumpsRemaining = _maxJumps;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _jumpButton = $"P{_playerNumber}Jump";
        _horizontalAxis = $"P{_playerNumber}Horizontal";
        _defaultLayerMask = LayerMask.GetMask("Default");
}


    void Update() {

        GetColliderAtFeet();
        UpdateIsGrounded();

        if (UpdateIsOnIce())
            SlipHorizontal();
        else
            MoveHorizontal();

        ReadHorizontalInput();

        UpdateAnimator();
        UpdateSpriteDirection();

        if (ShouldStartJump()) {
            Jump();
        }

        else if (ShouldContinueJump()) {
            ContinueJumping();
        }

        IncrementJumpTimer();

        if (_isGrounded && _fallTimer > 0.5f) {
            ResetJump();
        }

        else {
            IncreasePlayerFallSpeed();
        }
    }

    void IncreasePlayerFallSpeed() {
        _fallTimer += Time.deltaTime;
        var downForce = _downPull * _fallTimer * _fallTimer;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y - downForce);
    }

    void ResetJump() {
        _fallTimer = 0;
        _jumpsRemaining = _maxJumps;
    }

    void IncrementJumpTimer() {
        _jumpTimer += Time.deltaTime;
    }

    void ContinueJumping() {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
        _fallTimer = 0;
    }

    bool ShouldContinueJump() {
        return Input.GetButton(_jumpButton) && _jumpTimer <= maxJumpDuration;
    }

    void Jump() {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
        _jumpsRemaining--;
        _fallTimer = 0;
        _jumpTimer = 0;
    }

    bool ShouldStartJump() {
        return Input.GetButtonDown(_jumpButton) && _jumpsRemaining > 0;
    }

    void MoveHorizontal() {
     
        _rigidbody2D.velocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
    }

    void SlipHorizontal() {

        var _desiredVelocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
        var _smoothedVelocity = Vector2.Lerp(_rigidbody2D.velocity, _desiredVelocity, Time.deltaTime / _slipFactor);
        _rigidbody2D.velocity = _smoothedVelocity;
    }

    void ReadHorizontalInput() {
        _horizontal = Input.GetAxis(_horizontalAxis) * _speed;
    }

    void UpdateSpriteDirection() {
        if (_horizontal != 0) {
            _spriteRenderer.flipX = _horizontal < 0;
        }
    }

    void UpdateAnimator() {
        bool walking = _horizontal != 0;
        _animator.SetBool("Walk", walking);
        _animator.SetBool("Jump", ShouldContinueJump());
    }

    void UpdateIsGrounded() {
        
        _isGrounded = hit != null;
    }
    bool UpdateIsOnIce() {

        if (hit != null)
            return hit.CompareTag("Slippery");
        else
            return false;
    }

    private void GetColliderAtFeet() {
        hit = Physics2D.OverlapCircle(_feet.position, 0.01f, _defaultLayerMask);
    }

    internal void ResetToStart() {

        _rigidbody2D.position = _startPosition;
    }

    internal void TeleportTo(Vector3 position) {
        
        _rigidbody2D.position = position;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
