using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float dragPower;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera camera;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    Rigidbody2D rigidbody2D;

    private void Start()
    {
        camera = Camera.main;
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime);
        }

        if(Input.GetMouseButtonDown(0))
        {
            startPoint = camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButtonUp(0))
        {
            endPoint = camera.ScreenToWorldPoint(Input.mousePosition);

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                                Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rigidbody2D.velocity = force * dragPower;
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
}
