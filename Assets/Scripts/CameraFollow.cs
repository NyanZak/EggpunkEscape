using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 minValue, maxValue;
    public float smoothFactor;
    void FixedUpdate()
    {
        Vector3 boundPosition = new Vector3(
                Mathf.Clamp(target.position.x, minValue.x, maxValue.x),
                Mathf.Clamp(target.position.y, minValue.y, maxValue.y),
                Mathf.Clamp(target.position.z, minValue.z, maxValue.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
