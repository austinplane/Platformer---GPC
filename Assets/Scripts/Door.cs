using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {


    [SerializeField] Sprite _doorOpenMid;
    [SerializeField] Sprite _doorOpenTop;

    SpriteRenderer _rendererMid;
    SpriteRenderer _rendererTop;

    void Start() {

        _rendererMid = GetComponent<SpriteRenderer>();
        _rendererTop = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    
    void Update() {
        

    }

    [ContextMenu("Open Door")]
    void Open() {

        _rendererMid.sprite = _doorOpenMid;
        _rendererTop.sprite = _doorOpenTop;
    }
}
