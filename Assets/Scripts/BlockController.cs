using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockController : MonoBehaviour
{
    [SerializeField] ColorLine colorLine;

    [SerializeField] public List<GameObject[]> allHumans = new List<GameObject[]>();

    [SerializeField] private GameObject[] humans0;
    [SerializeField] private GameObject[] humans1;
    [SerializeField] private GameObject[] humans2;
    [SerializeField] private GameObject[] humans3;
    [SerializeField] private GameObject[] humans4;
    [SerializeField] private GameObject[] humans5;
    [SerializeField] private GameObject[] humans6;
    [SerializeField] private GameObject[] humans7;

    private GameColors _lineGameColors = new GameColors(5);

    private void Awake()
    {
        allHumans.Add(humans0);
        allHumans.Add(humans1);
        allHumans.Add(humans2);
        allHumans.Add(humans3);
        allHumans.Add(humans4);
        allHumans.Add(humans5);
        allHumans.Add(humans6);
        allHumans.Add(humans7);
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
        colorLine.SetLineColor(randomNum);
        _lineGameColors.SetIndexColorTo(randomNum);
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
}
