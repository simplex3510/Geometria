using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;
    Vector2 oldVelocity;

    bool isBattle = false;

    private void Update()
    {
        if (isBattle)
        {
            oldVelocity = playerRigidbody2D.velocity;
            playerRigidbody2D.velocity = Vector2.zero;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.Destroy(this.gameObject);
                playerRigidbody2D.velocity = oldVelocity;
                PlayerCameraMove.isZoom = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isBattle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isBattle = false;
        }
    }
}
