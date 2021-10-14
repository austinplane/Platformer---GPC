using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : HittableFromBelow {

    [SerializeField] int _totalCoins = 3;

    protected override bool CanUse => _remainingCoins > 0;

    int _remainingCoins;

    void Start() {

        _remainingCoins = _totalCoins;

    }

    protected override void Use() {

        Coin.CoinsCollected++;
        _remainingCoins--;
        GetComponent<AudioSource>().Play();
    }
}

