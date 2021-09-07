using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] private int countStartPartTails = 3;
    private GameColors _tailGameColor = new GameColors(1);
    private Player player;
    Transform _transform;
    List<GameObject> partsOfTail = new List<GameObject>();
    private Color currentColor;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Player>();
        _transform = transform;
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
        DestroyTail();
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
        //точно transform.up?
        var vector = new Vector3(0, -1, 0);
        partOfTail.transform.position = _transform.transform.position - _transform.transform.up * 2;
        partOfTail.transform.rotation = _transform.rotation;
        partOfTail.target = _transform.transform;
        partOfTail.targetDistance = 1;
        partOfTail.GetComponent<Collider>().isTrigger = true;
        var rb = go.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        _transform = partOfTail.transform;
        partsOfTail.Add(go);
    }

    // public void ChangeColor(GameColors newColor)
    // {
    //     SetCurrentColor(newColor);
    //     // Debug.Log(partsOfTail.Count);
    //     foreach (var tail in partsOfTail)
    //     {
    //         // tail.GetComponent<Renderer>().material.color = newColor.GetColor();
    //         // Debug.Log(tail);
    //     }
    // }

    void SetCurrentColor(GameColors color)
    {
        _tailGameColor = color;
    }

    GameColors GetSnakeColor()
    {
        return player.GetCurrentColor();
    }

    public void DestroyTail()
    {
        foreach (var tail in partsOfTail)
        {
            Destroy(tail);
        }
        partsOfTail = new List<GameObject>();
        _transform = transform;
    }

    public void RestartTail()
    {
        CreateTail();
    }
}
