using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    
    Rigidbody2D _rigidbody;
    
    [SerializeField] float _fireballSpeed;

    public float Direction { get; set; }

    void Awake() {

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start() {

        _rigidbody.velocity = new Vector2(_fireballSpeed * Direction, 1);
        Destroy(this.gameObject, 2f);
    }


    void OnCollisionEnter2D(Collision2D collision) {

        _rigidbody.velocity = new Vector2(_fireballSpeed * Direction, _rigidbody.velocity.y);
    }
}
