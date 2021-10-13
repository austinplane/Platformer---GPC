using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour {

    [SerializeField] Fireball _fireballPrefab;

    Player _player;
    string _fireButton;
    bool _canFire;

    void Awake() {

        _player = GetComponent<Player>();
    }


    void Start() {

        _fireButton = $"P{_player.PlayerNumber}Fire";
        _canFire = true;
    }

    
    void Update() {

        if (Input.GetAxis(_fireButton) > 0.5 && _canFire) {
            Instantiate(_fireballPrefab, transform.position, Quaternion.identity);
            _canFire = false;
            StartCoroutine(WaitToFire());
        }
    }

    IEnumerator WaitToFire() {

        yield return new WaitForSeconds(0.5f);
        _canFire = true;
    }
}
