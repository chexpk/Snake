using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeControl : MonoBehaviour
{
    [SerializeField] float speed = 25f;
    [SerializeField] private int speedBoost = 3;
    [SerializeField] private Camera cam;
    [SerializeField] private bool isMove = false;
    [SerializeField] private bool isFever = false;

    [Header("Position on road")]
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;

    private float normalSpeed;
    private float smoothTime = 0.08f;
    private float positionYTargetCorrector;
    private Vector3 velocity = Vector3.zero;
    private Transform _transform;


    private void Awake()
    {
        _transform = transform;
    }

    void Start()
    {
        normalSpeed = speed;
    }

    void Update()
    {
        MoveByRayCast();
    }

    public void SetPositionToRestart(Vector3 position)
    {
        _transform.position = position;
    }

    public void SetIsMove(bool move)
    {
        isMove = move;
    }

    public void SetIsFever(bool fever)
    {
        isFever = fever;
        if (fever)
        {
            IncreaseSpeedByIndexTimes(speedBoost);
            return;
        }
        SetSpeedToNormal();
    }

    void MoveByRayCast()
    {
        if (!isMove) return;

        var targetPosition = GetConstantTargetPosition();
        if(Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            targetPosition = SetNewTargetPosition(ray);
        }
        if(Input.touchCount > 0)
        {
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            targetPosition = SetNewTargetPosition(ray);
        }

        if (isFever)
        {
            var middleX = (maxX + minX) / 2;
            targetPosition = new Vector3(middleX, _transform.position.y + SetCurrPositionYTargetCorrector(), _transform.position.z);
        }

        _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref velocity, smoothTime);
        _transform.LookAt(targetPosition, new Vector3(0, 0, -1));
    }

    void IncreaseSpeedByIndexTimes(int indexOfSpeed)
    {
        speed = normalSpeed * indexOfSpeed;
    }

    void SetSpeedToNormal()
    {
        speed = normalSpeed;
    }

    float SetCurrPositionYTargetCorrector()
    {
        return positionYTargetCorrector = speed * smoothTime;
    }

    Vector3 SetNewTargetPosition(Ray ray)
    {
        if (Physics.Raycast(ray, out var hit))
        {
            var hitPosition = hit.point;
            float xPos = Mathf.Clamp(hitPosition.x, minX, maxX);
            return new Vector3(xPos, _transform.position.y + SetCurrPositionYTargetCorrector(), _transform.position.z);
        }
        return GetConstantTargetPosition();
    }

    Vector3 GetConstantTargetPosition() {
        return new Vector3(_transform.position.x, _transform.position.y + SetCurrPositionYTargetCorrector(), _transform.position.z);
    }
}
