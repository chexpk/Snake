using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnRoad : MonoBehaviour
{
    public enum ObjectType
    {
        human,
        crystal,
        trap
    }

    public ObjectType type;
    private GameColors humanColor = new GameColors(5);

    [SerializeField] private float speedOfPulling = 30;
    [SerializeField] private float liveTimeBetweenEatenAndDestroyed = 0.15f;

    private bool isPulled = false;
    private Transform targetToPulling;
    Collider m_Collider;

    Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        m_Collider = GetComponent<Collider>();
    }

    void Start()
    {
        if ((int) type == 0)
        {
            SetColor(humanColor);
        }
    }

    private void Update()
    {
        if (isPulled)
        {
            PulledToSnakeHead();
        }
    }

    public ObjectType GetObjectType()
    {
        return type;
    }

    public int GetIndexOfHumanColor()
    {
        return humanColor.GetIndexOfColor();
    }

    public void SetHumanColor(int indexOfHumanColor)
    {
        if ((int) type != 0) return;
        humanColor.SetIndexColorTo(indexOfHumanColor);
        SetColor(humanColor);
    }

    public void Eaten(Transform target)
    {
        if ((int) type != 0)
        {
            DisableThisGo();
        } else {
            targetToPulling = target;
            isPulled = true;

            m_Collider.enabled = false;
            Invoke("DisableThisGo", liveTimeBetweenEatenAndDestroyed);
        }
    }

    void PulledToSnakeHead()
    {
        Vector3 direction = (targetToPulling.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        if (targetToPulling == null) return;
        float step =  speedOfPulling * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetToPulling.position, step);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    void SetColor(GameColors color)
    {
        _renderer.material.color = color.GetColor();
    }

    void DisableThisGo()
    {
        gameObject.SetActive(false);
    }
}
