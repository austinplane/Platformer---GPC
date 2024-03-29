﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collectible : MonoBehaviour {

    public event Action OnPickedUp;

    private void OnTriggerEnter2D(Collider2D collider) {

        var player = collider.GetComponent<Player>();
        
        if (player == null)
            return;

        gameObject.SetActive(false);

        OnPickedUp?.Invoke();
    }
}