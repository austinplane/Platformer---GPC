using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    [SerializeField] KeyLock _keyLock;

    private void OnTriggerEnter2D(Collider2D collider) {

        var player = collider.GetComponent<Player>();

        if (player != null) {

            transform.SetParent(player.transform);
            transform.localPosition = Vector3.up;
            GetComponent<AudioSource>().Play();
        }

        var keylock = collider.GetComponent<KeyLock>();
        if (keylock != null && keylock == _keyLock) {

            keylock.Unlock();
            Destroy(gameObject);
        }

    }
}
