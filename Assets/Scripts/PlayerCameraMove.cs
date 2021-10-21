using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    public Transform player;

    float offset = -10f;
    float zoomIn = 10f;
    float zoomOut = 13f;
    float zoomPower = 0.1f;
    public static bool isZoom;
    
    Camera mainCamera;

    private void Start()
    {
        isZoom = false;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        mainCamera.transform.position = new Vector3(player.position.x, player.position.y, offset);
    }

    private void LateUpdate()
    {
        if (isZoom)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomIn, zoomPower);
        }
        else
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomOut, zoomPower);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isZoom = true;
        }
    }

    private void OnTriggerExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isZoom = false;
        }
    }
}
