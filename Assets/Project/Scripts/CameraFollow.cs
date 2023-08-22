using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _focusSpeed = 5f;

    private void FixedUpdate()
    {
        if (_target)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _focusSpeed);
        }
    }
}
