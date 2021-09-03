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

    void Start() {

        _rendererMid = GetComponent<SpriteRenderer>();
        _rendererTop = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    
    void Update() {

        if (Coin.CoinsCollected >= _requiredCoins)
            Open();
    }

    [ContextMenu("Open Door")]
    void Open() {

        _doorOpen = true;
        _rendererMid.sprite = _doorOpenMid;
        _rendererTop.sprite = _doorOpenTop;
    }

    void OnTriggerEnter2D(Collider2D collider) {

        var player = collider.GetComponent<Player>();

        if (player == null)
            return;

        if (_exit != null && _doorOpen)
            player.TeleportTo(_exit.transform.position);
    }
}
