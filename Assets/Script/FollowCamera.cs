using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    //public Vector3 offset;
    public float smoothness = 10f;
    public float distance = 5f;
    public float height = 2f;
    public float rotationOffset = 10f;
    //void Start()
    //{
    //    offset = transform.position - target.position;

    //}

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position - target.forward * distance;
        desiredPosition += Vector3.up * height;
        Quaternion desiredRotation = Quaternion.Euler(rotationOffset, target.eulerAngles.y, 0);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothness * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothness * Time.deltaTime);
    }
}
