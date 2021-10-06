using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : HittableFromBelow {
    
    [SerializeField] GameObject _item;
    [SerializeField] Vector2 _itemLaunchVelocity;
    
    bool _itemUsed;

    void Start() {

        _item.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (_itemUsed)
            return;

        var player = collision.collider.GetComponent<Player>();

        if (player == null)
            return;

        if (collision.contacts[0].normal.y > 0) {

            GetComponent<SpriteRenderer>().sprite = _usedSprite;

            _itemUsed = true;
            _item.SetActive(true);
            
            var itemRigidBody = _item.GetComponent<Rigidbody2D>();
            if (itemRigidBody != null) {

                itemRigidBody.velocity = _itemLaunchVelocity;
            }
        }
    }
}
