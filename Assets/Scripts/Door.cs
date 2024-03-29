using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {


    [SerializeField] Sprite _doorOpenMid;
    [SerializeField] Sprite _doorOpenTop;

    SpriteRenderer _rendererMid;
    SpriteRenderer _rendererTop;
    
    [SerializeField] int _requiredCoins = 3;
    [SerializeField] Door _exit;
    bool _doorOpen;

    [SerializeField] Canvas _canvas;

    void Start() {

        _rendererMid = GetComponent<SpriteRenderer>();
        _rendererTop = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        
    }

    
    void Update() {

        if (!_doorOpen && Coin.CoinsCollected >= _requiredCoins)
            Open();
    }

    [ContextMenu("Open Door")]
    void Open() {

        _doorOpen = true;
        var _audioSource = GetComponent<AudioSource>();
        if (_audioSource != null)
            _audioSource.Play();

        _rendererMid.sprite = _doorOpenMid;
        _rendererTop.sprite = _doorOpenTop;

        if (_canvas != null)
            _canvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if (!_doorOpen)
            return;

        var player = collider.GetComponent<Player>();

        if (player != null && _exit != null)         
            player.TeleportTo(_exit.transform.position);
    }
}
