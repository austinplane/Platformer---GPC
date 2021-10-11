using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UICoinsCollected : MonoBehaviour {


    TMP_Text _text;


    void Start() {

        _text = GetComponent<TMP_Text>();
    }

    
    void Update() {

        _text.SetText($"Coins Collected: {Coin.CoinsCollected}");
    }
}
