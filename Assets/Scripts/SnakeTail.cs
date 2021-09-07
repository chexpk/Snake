using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] private int countStartPartsTail = 3;

    private Player player;
    Transform _transform;
    private GameColors _tailGameColor = new GameColors(1);
    List<GameObject> partsOfTail = new List<GameObject>();

    void Awake()
    {
        player = GetComponent<Player>();
        _transform = transform;
    }

    private void Start()
    {
        CreateTail();
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

    public void IncreaseTail()
    {
        SetCurrentColor(GetSnakeColor());
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        PartOfTail partOfTail = go.AddComponent<PartOfTail>();
        partOfTail.GetComponent<Renderer>().material.color = _tailGameColor.GetColor();
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

    void CreateTail()
    {
        DestroyTail();
        for (int i = 0; i < countStartPartsTail; i++)
        {
            IncreaseTail();
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
