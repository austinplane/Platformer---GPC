using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    
    


    void Awake() {
	
    }


    void Start() {
        Debug.Log("This is a test.");
    }

    
    void Update() {

        var horizontal = Input.GetAxis("Horizontal");
        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
        Debug.Log($"Velocity = {rigidbody2D.velocity}");
        //test comment
    }
}
