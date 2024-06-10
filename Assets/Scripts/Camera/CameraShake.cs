using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera camera;
    public float shakeDuration;
    public float shakeMagnitude;

    private Vector3 originalPos;
    private float shakeTime = 0f;

    void Start()
    {
        camera = Camera.main;
        originalPos = camera.transform.localPosition;
    }

    void Update()
    {
        if (shakeTime >0)
        {
            camera.transform.localPosition = originalPos + Random.insideUnitSphere * shakeMagnitude;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0f;
            camera.transform.localPosition = originalPos;
        }
    }

    public void TriggerShake()
    {
        shakeTime = shakeDuration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            TriggerShake();
        }
    }
}
