using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public enum GameColor
    {
        green,
        red,
        blue,
        yellow,
        magenta,
        white,
        black
    }

    // private GameColor tailColor;
    [SerializeField] private int countStartPartTails = 3;
    private GameColors _tailGameColor = new GameColors(5);
    private Player player;
    Transform current;
    List<PartOfTail> partsOfTail =new List<PartOfTail>();
    private Color currentColor;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Player>();
        current = transform;
    }

    private void Start()
    {
        CreateTail();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateTail()
    {

        for (int i = 0; i < countStartPartTails; i++)
        {
            IncreaseTail();
        }
    }

    public void IncreaseTail()
    {
        SetCurrentColor(GetSnakeColor());
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        PartOfTail partOfTail = go.AddComponent<PartOfTail>();
        partOfTail.GetComponent<Renderer>().material.color = _tailGameColor.GetColor();
        partOfTail.transform.position = current.transform.position - current.transform.up * 2;
        partOfTail.transform.rotation = transform.rotation;
        partOfTail.target = current.transform;
        partOfTail.targetDistance = 1;
        partOfTail.GetComponent<Collider>().isTrigger = true;
        var rb = go.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        current = partOfTail.transform;
        partsOfTail.Add(partOfTail.GetComponent<PartOfTail>());
    }

    public void ChangeColor(GameColors newColor)
    {
        SetCurrentColor(newColor);
        // Debug.Log(partsOfTail.Count);
        foreach (var tail in partsOfTail)
        {
            // tail.GetComponent<Renderer>().material.color = newColor.GetColor();
            // Debug.Log(tail);
        }
    }

    void SetCurrentColor(GameColors color)
    {
        _tailGameColor = color;
    }

    GameColors GetSnakeColor()
    {
        return player.GetCurrentColor();
    }
}
