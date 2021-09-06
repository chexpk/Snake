using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockController : MonoBehaviour
{
    private GameColors _lineGameColors = new GameColors(5);
    [SerializeField] ColorLine colorLine;
    [SerializeField] List<GameObject> allCrystals = new List<GameObject>();
    [SerializeField] List<GameObject> allTraps = new List<GameObject>();

    [SerializeField] public List<GameObject[]> allHumans = new List<GameObject[]>();

    [SerializeField] private GameObject[] humans0;
    [SerializeField] private GameObject[] humans1;
    [SerializeField] private GameObject[] humans2;
    [SerializeField] private GameObject[] humans3;
    [SerializeField] private GameObject[] humans4;
    [SerializeField] private GameObject[] humans5;
    [SerializeField] private GameObject[] humans6;

    private void Awake()
    {
        allHumans.Add(humans0);
        allHumans.Add(humans1);
        allHumans.Add(humans2);
        allHumans.Add(humans3);
        allHumans.Add(humans4);
        allHumans.Add(humans5);
        allHumans.Add(humans6);
    }

    private void Start()
    {
        SetRandomColorToLine();
        SetColorToHumans();
    }

    void SetRandomColorToLine()
    {
        int lengthEnum = _lineGameColors.Length();
        int randomNum = Random.Range(0, lengthEnum);
        // lineColors = (LineColors)randomNum;
        // var stringColor = lineColors.ToString();
        // ColorUtility.TryParseHtmlString(stringColor, out var color);
        colorLine.SetLineColor(randomNum);
        _lineGameColors.SetIndexColorTo(randomNum);
        // colorLine.GetComponent<Renderer>().material.color = color;
        // currentLineColor = color;
    }

    void SetColorToHumans()
    {
        var anotherColor = GetAnotherColorIndex();
        int indexOfColor;
        foreach (var humans in allHumans)
        {
            if (Random.Range(0, 2) != 0)
            {
                indexOfColor = _lineGameColors.GetIndexOfColor();
            } else
            {
                indexOfColor = anotherColor;
            }
            foreach (var goHum in humans)
            {
                goHum.SetActive(true);
                goHum.GetComponent<ObjectOnRoad>().SetHumanColor(indexOfColor);
            }
        }
    }

    int GetAnotherColorIndex()
    {
        int lengthEnum = _lineGameColors.Length();
        int randomNum = 0;
        do
        {
            randomNum = Random.Range(0, lengthEnum);
        }
        while (randomNum == _lineGameColors.GetIndexOfColor());
        return randomNum;
    }

    void Restart()
    {
        SetRandomColorToLine();
        SetColorToHumans();
        SetActiveToCrystalsAndTraps();
    }

    void SetActiveToCrystalsAndTraps()
    {
        foreach (var crystal in allCrystals)
        {
            crystal.SetActive(true);
        }
        foreach (var trap in allTraps)
        {
            trap.SetActive(true);
        }
    }
}
