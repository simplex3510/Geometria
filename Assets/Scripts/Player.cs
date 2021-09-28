using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rigidbody2D;

    bool isPressed = false;
    // bool is

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime);
        }

        if(isPressed)
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("충돌");
        if (other.gameObject.tag == "Outside")
        {
            Debug.Log("경계");
        }

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("적");
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("차징 시작");
        isPressed = true;
    }

    private void OnMouseUp()
    {
        Debug.Log("이동 시작");
        isPressed = false;
    }
}
