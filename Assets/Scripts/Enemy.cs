using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;

    bool isBattle = false;



    private void Update()
    {
        if (isBattle)
        {
            Vector2 oldVelocity = playerRigidbody2D.velocity;
            playerRigidbody2D.velocity = Vector2.zero;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(gameObject);
                playerRigidbody2D.velocity = oldVelocity;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isBattle = true;
        }
    }
}
