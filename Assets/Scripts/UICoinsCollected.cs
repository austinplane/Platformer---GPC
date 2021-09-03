using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinsCollected : MonoBehaviour {


    Text _text;


    void Start() {

        _text = GetComponent<Text>();
    }

    
    void Update() {

        _text.text = $"Coins Collected: {Coin.CoinsCollected}";
    }
}
