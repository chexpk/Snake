using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private float offset = 0;
    [SerializeField] Transform target;

    Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(_transform.position.x, target.position.y + offset, _transform.position.z);
    }
}
