using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : HittableFromBelow {
    
    [SerializeField] GameObject _item;
    [SerializeField] Vector2 _itemLaunchVelocity;

    bool _itemUsed = false;
    protected override bool CanUse => !_itemUsed;

    void Start() {

        _item?.SetActive(false);
    }


    protected override void Use() {
        
        base.Use();
        _itemUsed = true;
        _item?.SetActive(true);

        var itemRigidBody = _item?.GetComponent<Rigidbody2D>();
        if (itemRigidBody != null) {

            itemRigidBody.velocity = _itemLaunchVelocity;
        }
    }
}
