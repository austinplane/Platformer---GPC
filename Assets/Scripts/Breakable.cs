using UnityEngine;

public class Breakable : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.collider.GetComponent<Player>() == null)
            return;

        if (collision.contacts[0].normal.y > 0) {

            TakeHit();
        }
    }

    private void TakeHit() {

        gameObject.SetActive(false);
    }
}
