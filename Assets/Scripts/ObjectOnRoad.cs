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

    public enum HumanColor
    {
        green,
        red,
        blue,
        yellow,
        magenta,
        white,
        black
    }

    [SerializeField] public ObjectType type;
    [SerializeField] private HumanColor humanColor = HumanColor.white;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        // partOfTail.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        // type = ObjectType.human;
        // humanColor = HumanColor.white;
        // Debug.Log(type);
        // Debug.Log(type.ToString());
        // Debug.Log((int)type);
        if ((int) type == 0)
        {
            // Debug.Log("зашел");
            var col = ConvertToColor(humanColor);
            SetColor(col);
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
        return (int)humanColor;
    }

    void SetColor(Color color)
    {
        _renderer.material.color = color;
    }

    Color ConvertToColor(HumanColor humanCol)
    {
        ColorUtility.TryParseHtmlString(humanCol.ToString(), out var color);
        return color;
    }

    public void SetHumanColor(int indexOfHumanColor)
    {
        if ((int) type != 0) return;
        humanColor = (HumanColor) indexOfHumanColor;
        SetColor(ConvertToColor(humanColor));
    }
}
