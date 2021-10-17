using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    Camera playerCamera;
    Vector2 minDistance = new Vector2(-3, -3);
    Vector2 maxDistance = new Vector2(3, 3);
    Vector2 direction;
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
        #region DragMove
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = playerCamera.ScreenToWorldPoint(Input.mousePosition);

            direction = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minDistance.x, maxDistance.x),
                                    Mathf.Clamp(startPoint.y - endPoint.y, minDistance.y, maxDistance.y));
            Debug.Log(direction.ToString());
        }

        Vector2 position = playerRigidbody2D.position;
        playerRigidbody2D.MovePosition(position + direction);

        

        #endregion
    
    }
}
