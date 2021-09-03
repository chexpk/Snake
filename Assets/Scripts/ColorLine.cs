using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLine : MonoBehaviour
{
    GameColors _lineGameColor;
    private Renderer _renderer;
    [SerializeField]  ParticleSystem[] particles;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLineColor(int indexOfColor)
    {
        _lineGameColor = new GameColors(indexOfColor);
        _renderer.material.color = _lineGameColor.GetColor();
        SetColorToParticles();
    }

    void SetColorToParticles()
    {
        foreach (var ps in particles)
        {
            var main = ps.main;
            main.startColor = _lineGameColor.GetColor();
        }
    }

    public GameColors GetColor()
    {
        return _lineGameColor;
    }
}
