
using System;
using UnityEngine;

[System.Serializable]
public class GameColors
{
    public enum AllGameColors
    {
        green,
        red,
        blue,
        yellow,
        magenta,
        grey,
        black
    }

    [SerializeField] AllGameColors color;

    public GameColors(int indexOfColor)
    {
        color = (AllGameColors) indexOfColor;
    }

    public int GetIndexOfColor()
    {
        return (int) color;
    }

    public void SetIndexColorTo(int indexOfColor)
    {
        color = (AllGameColors) indexOfColor;
    }

    public string GetStringNameOfColor()
    {
        return color.ToString();
    }

    public Color GetColor()
    {
        ColorUtility.TryParseHtmlString(GetStringNameOfColor(), out var col);
        return col;
    }

    public int Length()
    {
        return Enum.GetValues(typeof(AllGameColors)).Length;
    }
}
