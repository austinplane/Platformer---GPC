using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour {

    [SerializeField] Fireball _fireballPrefab;

    Player _player;
    string _horizontalAxis;
    SpriteRenderer _spriteRenderer;
    string _fireButton;
    bool _canFire;

    

    void Awake() {

        _player = GetComponent<Player>();
        _horizontalAxis = $"P{_player.PlayerNumber}Horizontal";
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Start() {

        _fireButton = $"P{_player.PlayerNumber}Fire";
        _canFire = true;
    }

    
    void Update() {

        if (Input.GetAxis(_fireButton) > 0.5 && _canFire) {

            Fireball fireball = Instantiate(_fireballPrefab, transform.position, Quaternion.identity);
            fireball.Direction = _spriteRenderer.flipX ? -1f : 1f;
            _canFire = false;
            StartCoroutine(WaitToFire());
        }
    }

    IEnumerator WaitToFire() {

        yield return new WaitForSeconds(0.5f);
        _canFire = true;
    }
}
