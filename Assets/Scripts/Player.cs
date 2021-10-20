using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    Camera playerCamera;
    Rigidbody2D playerRigidbody2D;
    Vector2 minDistance = new Vector2(-5, -5);
    Vector2 maxDistance = new Vector2(5, 5);
    Vector3 direction;
    Vector3 startPoint;
    Vector3 endPoint;
    

    private void Start()
    {
        playerCamera = Camera.main;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region DragMove
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 0;

            direction = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minDistance.x, maxDistance.x),
                                    Mathf.Clamp(startPoint.y - endPoint.y, minDistance.y, maxDistance.y));

            
            Debug.Log(direction.ToString());
        }

        playerRigidbody2D.velocity = direction * moveSpeed * Time.deltaTime;


        #endregion

    }
}
