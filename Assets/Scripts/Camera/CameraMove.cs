using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    float timeOffset;


    [SerializeField]
    Vector2 posOffset;

    private Vector3 velocity;


     void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = player.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10f;

        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);
    }
}
