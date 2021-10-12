using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    
    public static int CoinsCollected;

    AudioSource _audioSource;

    void Start() {

        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider) {

        var player = collider.GetComponent<Player>();

        if (player == null)
            return;

        _audioSource.Play();

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        CoinsCollected++;
        ScoreSystem.AddScore(100);

        StartCoroutine(StartDelayBeforeDestroy());             
    }

    IEnumerator StartDelayBeforeDestroy() {

        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
