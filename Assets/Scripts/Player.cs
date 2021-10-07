using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float dragPower;
    public Vector2 minPower;
    public Vector2 maxPower;

    bool isBattle = false;
    Camera playerCamera;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    Rigidbody2D playerRigidbody2D;

    private void Start()
    {
        playerCamera = Camera.main;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime);
        }

        DragMove();
    }

    void DragMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = playerCamera.ScreenToWorldPoint(Input.mousePosition);

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                                Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            playerRigidbody2D.velocity = force * dragPower;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isBattle = true;
            PlayerCameraMove.isZoom = true;

            Vector2 oldVelocity = playerRigidbody2D.velocity;
            playerRigidbody2D.velocity = Vector2.zero;
            Battle(other);
            playerRigidbody2D.velocity = oldVelocity;
        }
    }

    void Battle(Collision2D enemy)
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        Debug.Log("space bar");
        Destroy(enemy.gameObject);
        PlayerCameraMove.isZoom = false;
        // }
        isBattle = false;
    }
}
