using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collectible : MonoBehaviour {
    
    List<Collector> _collectors = new List<Collector>();

    private void OnTriggerEnter2D(Collider2D collider) {

        var player = collider.GetComponent<Player>();
        
        if (player == null)
            return;

        gameObject.SetActive(false);
        
        foreach (var collector in _collectors)
            collector.ItemPickedUp();
    }

    public void AddCollector(Collector collector) {

        _collectors.Add(collector);
    }
}