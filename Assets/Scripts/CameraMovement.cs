using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        gameObject.transform.position = new Vector3(
            Mathf.Clamp(player.transform.position.x, -28.0f, 39.0f),
            Mathf.Clamp(player.transform.position.y, -1.0f, 66.0f),
            -10);
    }
}
