using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeControl : MonoBehaviour
{
    [SerializeField] float speed = 25f;
    private float normalSpeed;
    [SerializeField] private Camera cam;
    [SerializeField] private bool isMove = false;
    [SerializeField] private bool isFever = false;
    [SerializeField] private int speedBoost = 3;

    [Header("Position on road")]
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;

    private float smoothTime = 0.08f;
    private float positionYTargetCorrector;
    private Vector3 velocity = Vector3.zero;
    private Transform _transform;


    private void Awake()
    {
        _transform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.touchCount > 0)
        // {
        //     // MoveByRayCast(GetTouchPosition());
        // }
        //
        // if (Input.GetMouseButton(0))
        // {
        //     // MoveByRayCast(Input.mousePosition);
        // }

        MoveByRayCast();
        // Move();
    }

    void MoveByRayCast()
    {
        if (isMove != true) return;

        positionYTargetCorrector = speed * smoothTime;
        Vector3 targetPosition = new Vector3(_transform.position.x, _transform.position.y + positionYTargetCorrector, _transform.position.z);


        //TODO добавить ввод с тача

        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var hitPosition = hit.point;
                float xPos = Mathf.Clamp(hitPosition.x, minX, maxX);
                targetPosition = new Vector3(xPos, _transform.position.y + positionYTargetCorrector, _transform.position.z);
            }
        }

        if (isFever == true)
        {
            positionYTargetCorrector = speed * smoothTime;
            var middleX = (maxX + minX) / 2;
            targetPosition = new Vector3(middleX, _transform.position.y + positionYTargetCorrector, _transform.position.z);
        }

        _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref velocity, smoothTime);
        _transform.LookAt(targetPosition, new Vector3(0, 0, -1));
    }

    void Move()
    {
        if (isMove != true) return;

        positionYTargetCorrector = speed * smoothTime;
        Vector3 targetPosition = new Vector3(_transform.position.x, _transform.position.y + positionYTargetCorrector, _transform.position.z);


        if(Input.touchCount > 0)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                var hitPosition = hit.point;
                float xPos = Mathf.Clamp(hitPosition.x, minX, maxX);
                targetPosition = new Vector3(xPos, _transform.position.y + positionYTargetCorrector, _transform.position.z);
            }
        }

        if (isFever == true)
        {
            positionYTargetCorrector = speed * smoothTime;
            var middleX = (maxX + minX) / 2;
            targetPosition = new Vector3(middleX, _transform.position.y + positionYTargetCorrector, _transform.position.z);
        }

        _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref velocity, smoothTime);
        _transform.LookAt(targetPosition, new Vector3(0, 0, -1));
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

    void IncreaseSpeedByIndexTimes(int indexOfSpeed)
    {
        speed = normalSpeed * indexOfSpeed;
    }

    void SetSpeedToNormal()
    {
        speed = normalSpeed;
    }

    Vector3 GetTouchPosition()
    {
        return Input.GetTouch(0).position;
    }

    Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }

    public void SetPositionToRestart(Vector3 position)
    {
        _transform.position = position;
    }
}
