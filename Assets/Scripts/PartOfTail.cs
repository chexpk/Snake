using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartOfTail : MonoBehaviour
{
    public Transform target;
    public float targetDistance;
    private Renderer _renderer;
    private GameColors partTailColor = new GameColors(5);

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Update()
    {
        Vector3 direction = target.position - transform.position;

        float distance = direction.magnitude;
        if (distance > targetDistance)
        {
            transform.position += direction.normalized * (distance - targetDistance);
            transform.LookAt(target);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("colorLine"))
        {
            var colorLine = other.GetComponent<ColorLine>();
            partTailColor = colorLine.GetColor();
            _renderer.material.color = partTailColor.GetColor();
        }
    }
}
