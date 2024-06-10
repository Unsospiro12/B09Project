using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomInOut : MonoBehaviour
{
    public Transform player;
    public float distance = 5.0f;
    public float minDistance = 2.0f;
    public float maxDistance = 10.0f;
    public float zoomSpeed = 1.0f;

    private Vector3 offset;
    void Start()
    {
        player = GameManager.Instance.player.transform;
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        distance -= scrollInput * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Vector3 newPosition = player.position + offset.normalized * distance;
        transform.position = newPosition;

        transform.LookAt(player);
    }
}
