using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    
    public bool PlayerInside;
    
    HashSet<Player> _playersInTrigger = new HashSet<Player>();
    Vector3 _initialPosition;

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
            StartCoroutine(WiggleAndFall());
    }

    void OnTriggerExit2D(Collider2D collider) {

        var player = collider.GetComponent<Player>();
        if (player == null)
            return;

        _playersInTrigger.Remove(player);

        if (_playersInTrigger.Count == 0) {
            PlayerInside = false;
            StopCoroutine(WiggleAndFall());
        }
    }

    IEnumerator WiggleAndFall() {

        Debug.Log("Waiting to Wiggle");
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Wiggling");
        
        float wiggleTimer = 0f;

        while (wiggleTimer < 1f) {

            float randomX = UnityEngine.Random.Range(-0.05f, 0.05f);
            float randomY = UnityEngine.Random.Range(-0.05f, 0.05f);
            transform.position = _initialPosition + new Vector3(randomX, randomY);
            float randomDelay = UnityEngine.Random.Range(0.005f, 0.01f);
            yield return new WaitForSeconds(randomDelay);
            wiggleTimer += randomDelay;
        }

        yield return new WaitForSeconds(1f);
        Debug.Log("Falling");
        yield return new WaitForSeconds(3f);
    }
}
