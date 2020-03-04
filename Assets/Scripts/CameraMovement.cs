using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject _follow;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (_follow != null)
        {
            gameObject.transform.position = new Vector3(
                Mathf.Clamp(_follow.transform.position.x, -28.0f, 39.0f),
                Mathf.Clamp(_follow.transform.position.y, -1.0f, 66.0f),
                -10);
        }
        else
        {
            gameObject.transform.position = new Vector3(
                Mathf.Clamp(player.transform.position.x, -28.0f, 39.0f),
                Mathf.Clamp(player.transform.position.y, -1.0f, 66.0f),
                -10);
        }
    }
}
