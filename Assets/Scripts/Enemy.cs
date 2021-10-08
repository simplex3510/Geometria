using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    bool isBattle = false;


    private void Update()
    {
        if (player.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("space bar");
                Destroy(enemy);
                PlayerCameraMove.isZoom = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D player)
    {

    }
}
