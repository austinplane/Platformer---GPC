using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour {

    [SerializeField] List<Collectible> _collectiblesToCollect;
    [SerializeField] UnityEvent _onCollectionComplete;

    SpriteRenderer _rendererMid;
    SpriteRenderer _rendererTop;

    [SerializeField] Sprite _doorOpenMid;

    [SerializeField] Sprite _doorOpenTop;

    [SerializeField] Canvas _canvas;

    TMP_Text _remainingText;
    int _countCollected;

    void Awake() {
	
    }


    void Start() {
        
        _remainingText = GetComponentInChildren<TMP_Text>();

        foreach (var collectible in _collectiblesToCollect) {

            collectible.OnPickedUp += ItemPickedUp;
        }

        _remainingText?.SetText(_collectiblesToCollect.Count.ToString());

        _rendererMid = GetComponent<SpriteRenderer>();
        _rendererTop = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void ItemPickedUp() {

        Debug.Log("Picked up gem.");
        _countCollected++;
        int countRemaining = _collectiblesToCollect.Count - _countCollected;

        _remainingText?.SetText(countRemaining.ToString());

        if (countRemaining > 0)
            return;

        _onCollectionComplete?.Invoke();
    }

    private void OnValidate() {

        _collectiblesToCollect = _collectiblesToCollect.Distinct().ToList();
    }

    public void OpenDoor() {

        _rendererMid.sprite = _doorOpenMid;
        _rendererTop.sprite = _doorOpenTop;

        if (_canvas != null)
            _canvas.enabled = false;
    }

    void OnDrawGizmosSelected() {

        Gizmos.color = Color.yellow;
        
        foreach (var collectible in _collectiblesToCollect) {

            Gizmos.DrawLine(transform.position, collectible.transform.position);
        }
    }
    void OnDrawGizmos() {

        Gizmos.color = Color.gray;

        foreach (var collectible in _collectiblesToCollect) {

            Gizmos.DrawLine(transform.position, collectible.transform.position);
        }
    }
}
