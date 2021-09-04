using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    
    public bool PlayerInside;
    
    HashSet<Player> _playersInTrigger = new HashSet<Player>();
    Vector3 _initialPosition;
    bool _falling;
    float _wiggleTimer;
    Coroutine coroutine;

    [SerializeField] float _fallSpeed = 3;

    [Tooltip("Reset the wiggle timer when no players are on the platform")]
    [SerializeField] bool _resetOnEmpty;

    [Range(0.1f, 5f)]
    [SerializeField] float _fallAfterSeconds = 1;
    [Range(0.005f, 0.1f)] 
    [SerializeField] float _shakeX = 0.05f;
    [Range(0.005f, 0.1f)] 
    [SerializeField] float _shakeY = 0.05f;

    void Start() {

        _initialPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider) {

        var player = collider.GetComponent<Player>();
        if (player == null)
            return;

        _playersInTrigger.Add(player);

        PlayerInside = true;

        if (_playersInTrigger.Count == 1)
            coroutine = StartCoroutine(WiggleAndFall());
    }

    void OnTriggerExit2D(Collider2D collider) {

        var player = collider.GetComponent<Player>();
        if (player == null)
            return;

        if (_falling)
            return;

        _playersInTrigger.Remove(player);

        if (_playersInTrigger.Count == 0) {
            PlayerInside = false;
            StopCoroutine(coroutine);

            if (_resetOnEmpty)
                _wiggleTimer = 0f;
        }
    }

    IEnumerator WiggleAndFall() {

        Debug.Log("Waiting to Wiggle");
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Wiggling");
        
        while (_wiggleTimer < _fallAfterSeconds) {

            float randomX = UnityEngine.Random.Range(-_shakeX, _shakeX);
            float randomY = UnityEngine.Random.Range(-_shakeY, _shakeY);
            transform.position = _initialPosition + new Vector3(randomX, randomY);
            float randomDelay = UnityEngine.Random.Range(0.005f, 0.01f);
            yield return new WaitForSeconds(randomDelay);
            _wiggleTimer += randomDelay;
        }

        Debug.Log("Falling");

        _falling = true;
        //Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (var collider in GetComponents<Collider2D>()) {

            collider.enabled = false;
        }

        float _fallTimer = 0;

        while (_fallTimer < 3) {

            transform.position += Vector3.down * Time.deltaTime * _fallSpeed;
            _fallTimer += Time.deltaTime;
            yield return null;
        }


        Destroy(gameObject);
    }
}
