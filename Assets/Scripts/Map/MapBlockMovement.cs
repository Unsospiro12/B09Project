using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlockMovement : MonoBehaviour
{
    private float moveSpeed = 10f;
    private void Update()
    {
        transform.position += new Vector3(0, 0, -moveSpeed) * Time.deltaTime;

        if(transform.position.z < -65f)
        {
            Destroy(gameObject);
        }
    }
}
