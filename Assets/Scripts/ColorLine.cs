using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLine : MonoBehaviour
{
    [SerializeField]  ParticleSystem[] particles;
    GameColors lineGameColor;
    Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetLineColor(int indexOfColor)
    {
        lineGameColor = new GameColors(indexOfColor);
        _renderer.material.color = lineGameColor.GetColor();
        SetColorToParticles();
    }

    public GameColors GetColor()
    {
        return lineGameColor;
    }

    void SetColorToParticles()
    {
        foreach (var ps in particles)
        {
            var main = ps.main;
            main.startColor = lineGameColor.GetColor();
        }
    }
}
