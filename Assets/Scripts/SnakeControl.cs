using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControl : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float positionYTargetCorrectorSpeed = 0.3f;
    [SerializeField] private Camera cam;

    [SerializeField] private bool isMove = true;

    private Vector3 position;
    private Rigidbody headRb;

    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;

    [Header("Position on road")]
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;

    // Start is called before the first frame update
    void Start()
    {
        headRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // MoveByKeyboard();
        // Move();
        MoveByRayCast();
    }

    void Move()
    {
        //TODO make for touchControl
        if(Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            Debug.Log(mousePosition);
            var position = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(position);
            var targetPosition = new Vector3(position.x, transform.position.y + 1f, 1f);
            // Debug.Log(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }

    void MoveByKeyboard()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        headRb.velocity = new Vector3(moveHorizontal, 0, 1) * speed;
    }

    void MoveByRayCast()
    {
        if (isMove != true) return;

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + positionYTargetCorrectorSpeed, transform.position.z);

        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var hitPosition = hit.point;
                float xPos = Mathf.Clamp(hitPosition.x, minX, maxX);
                targetPosition = new Vector3(xPos, transform.position.y + positionYTargetCorrectorSpeed, transform.position.z);
            }
        }
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(targetPosition);

    }


}
