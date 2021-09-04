using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SnakeTail snakeTail;
    private SnakeControl snakeControl;
    private Renderer _renderer;
    private SnakeTouch snakeTouch;
    private GameColors _snakeGameColor = new GameColors(5);

    [SerializeField] private int feverTime = 5;
    [SerializeField] private int countEatenHumans = 0;

    [SerializeField] private int countEatenCrystals = 0;
    [SerializeField] private int countOfEatenInRowCrystals = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _snakeGameColor = new GameColors(5);
        snakeControl = GetComponent<SnakeControl>();
        snakeTail = GetComponent<SnakeTail>();
        _renderer = GetComponent<Renderer>();
        snakeTouch = GetComponent<SnakeTouch>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameColors GetCurrentColor()
    {
        return _snakeGameColor;
    }

    public void SetIsSnakeMove(bool move)
    {
        snakeControl.SetIsMove(move);
    }

    public void IncreaseTail()
    {
        snakeTail.IncreaseTail();
    }

    public void SetSnakeColor(GameColors gameColor)
    {
        _snakeGameColor = gameColor;
        _renderer.material.color = _snakeGameColor.GetColor();
    }

    public void IncreaseCountEatenHumans()
    {
        ++countEatenHumans;
        SetCountOfEatenInRowCrystalsToZero();
        IncreaseTail();
    }

    public void IncreaseCountEatenCrystals()
    {
        if (countOfEatenInRowCrystals > 2)
        {
            FeverModeOn();
        }
        ++countEatenCrystals;
        ++countOfEatenInRowCrystals;
    }

    void SetCountEatenCrystalsToZero()
    {
        countEatenCrystals = 0;
    }

    void SetCountOfEatenInRowCrystalsToZero()
    {
        countOfEatenInRowCrystals = 0;
    }

    void FeverModeOn()
    {
        snakeControl.SetIsFever(true);
        snakeTouch.SetIsFever(true);

        Invoke("FeverModeOff", feverTime);
    }

    void FeverModeOff()
    {
        snakeControl.SetIsFever(false);
        snakeTouch.SetIsFever(false);

        SetCountOfEatenInRowCrystalsToZero();
        SetCountEatenCrystalsToZero();
    }

}
