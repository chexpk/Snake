using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeControl : MonoBehaviour
{
    [SerializeField] float speed = 25f;
    [SerializeField] private Camera cam;
    [SerializeField] private bool isMove = true;

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

    }

    // Update is called once per frame
    void Update()
    {
        MoveByRayCast();
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

        _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref velocity, smoothTime);

        //TODO откорректировать поворот к цели
        _transform.LookAt(targetPosition, new Vector3(0, 0, -1));
        // Vector3 lookAtPosition = new Vector3(targetPosition.x, targetPosition.x, targetPosition.z);
        // _transform.LookAt(lookAtPosition);

        // var dir = targetPosition - _transform.position;
        // Quaternion LookAtRotation = Quaternion.LookRotation(dir);
        //
        // Quaternion LookAtRotationOnly_Y = Quaternion.Euler(LookAtRotation.eulerAngles.x, transform.rotation.eulerAngles.y, LookAtRotation.eulerAngles.z);
        // transform.rotation = LookAtRotationOnly_Y;
    }

    public void SetIsMove(bool move)
    {
        isMove = move;
    }


}
