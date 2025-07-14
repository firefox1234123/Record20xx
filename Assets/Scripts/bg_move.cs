using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_move : MonoBehaviour
{
    private Transform player;

    private Vector3 left = new Vector3((float)-9.7, 0, -10);
    private Vector3 right = new Vector3(0, 0, -10);

    private bool isThere = false;

    void Start()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
    }

    void Update()
    {
        if (player.position.x < -6.5 && !isThere)
        {
            transform.position = Vector3.Lerp(transform.position, left, 1f);
            isThere = true;
        }
        else if (player.position.x > -6.5 && isThere)
        {
            transform.position = Vector3.Lerp(transform.position, right, 1f);
            isThere = false;
        }
    }
}
