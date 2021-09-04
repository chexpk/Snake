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

    [SerializeField] public ObjectType type;
    [SerializeField] private GameColors humanColor = new GameColors(5);

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        if ((int) type == 0)
        {
            SetColor(humanColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ObjectType GetObjectType()
    {
        return type;
    }

    public int GetIndexOfHumanColor()
    {
        return humanColor.GetIndexOfColor();
    }

    void SetColor(GameColors color)
    {
        _renderer.material.color = color.GetColor();
    }

    public void SetHumanColor(int indexOfHumanColor)
    {
        if ((int) type != 0) return;
        humanColor.SetIndexColorTo(indexOfHumanColor);
        SetColor(humanColor);
    }
}
