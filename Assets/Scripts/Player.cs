using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    Camera playerCamera;
<<<<<<< Updated upstream
    Rigidbody2D playerRigidbody2D;
    Vector2 minDistance = new Vector2(-5, -5);
    Vector2 maxDistance = new Vector2(5, 5);
    Vector3 direction;
    Vector3 startPoint;
    Vector3 endPoint;
    
=======
    Vector2 minDistance = new Vector2(-5, -5);
    Vector2 maxDistance = new Vector2(5, 5);
    Vector2 direction;
    Vector3 startPoint;
    Vector3 endPoint;
    Rigidbody2D m_rigidbody2D;
>>>>>>> Stashed changes

    private void Start()
    {
        playerCamera = Camera.main;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
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

<<<<<<< Updated upstream
            
=======
>>>>>>> Stashed changes
            Debug.Log(direction.ToString());
            m_rigidbody2D.velocity = direction * moveSpeed;
        }
<<<<<<< Updated upstream

        playerRigidbody2D.velocity = direction * moveSpeed;


        #endregion

=======
        #endregion
>>>>>>> Stashed changes
    }
}
