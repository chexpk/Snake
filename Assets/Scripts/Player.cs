using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private int feverTime = 5;
    [SerializeField] private int countOfHumansToIncreaseTail = 4;
    [SerializeField] private int countOfCrystalsToFever = 3;

    [SerializeField] private BlocksGenerator blocksGenerator;
    [SerializeField] private UIController uiController;

    private SnakeTail snakeTail;
    private SnakeControl snakeControl;
    private Renderer _renderer;
    private SnakeTouch snakeTouch;
    private GameColors _snakeGameColor;

    public UnityEvent stopMove;

    private int countEatenHumans = 0;
    private int countEatenHumansToIncreaseTail = 0;
    private int countEatenCrystals = 0;
    private int countOfEatenInRowCrystals = 0;

    void Awake()
    {
        _snakeGameColor = new GameColors(1);
        snakeControl = GetComponent<SnakeControl>();
        snakeTail = GetComponent<SnakeTail>();
        _renderer = GetComponent<Renderer>();
        snakeTouch = GetComponent<SnakeTouch>();

    }

    public GameColors GetCurrentColor()
    {
        return _snakeGameColor;
    }

    public void SetIsSnakeMove(bool move)
    {
        snakeControl.SetIsMove(move);
        // snakeTail.DestroyTail();
    }
    public void SnakeCrashed()
    {
        SetIsSnakeMove(false);
        snakeTail.DestroyTail();
        stopMove.Invoke();
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
        CreatIncreaseCountText();
        ++countEatenHumans;
        SetCountOfEatenInRowCrystalsToZero();
        CheckIncreaseTail();

        SetCountHumansToUi(countEatenHumans);
    }

    public void RestartSnake(Vector3 basePosition)
    {
        snakeControl.SetPositionToRestart(basePosition);
        SetIsSnakeMove(true);
        _snakeGameColor = new GameColors(1);
        snakeTail.RestartTail();
        RestartAllCounts();
    }

    public void IncreaseCountEatenCrystals()
    {
        ++countEatenCrystals;
        ++countOfEatenInRowCrystals;
        if (countOfEatenInRowCrystals > countOfCrystalsToFever - 1)
        {
            FeverModeOn();
        }

        SetCountCrystalsToUi(countEatenCrystals);
    }


    void CheckIncreaseTail()
    {
        ++countEatenHumansToIncreaseTail;
        if (countEatenHumansToIncreaseTail > countOfHumansToIncreaseTail - 1)
        {
            IncreaseTail();
            countEatenHumansToIncreaseTail = 0;
        }
    }

    void SetCountEatenCrystalsToZero()
    {
        countEatenCrystals = 0;

        SetCountCrystalsToUi(countEatenCrystals);
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
        // SetCountEatenCrystalsToZero();
    }

    void CreatIncreaseCountText()
    {
        //создаю всплывающий текст
        // var go = Instantiate(Crt);
        // go.transform.SetParent(canvas.transform);
    }

    void SetCountCrystalsToUi(int count)
    {
        uiController.ChangeCrystalsCountText(count);
    }

    void SetCountHumansToUi(int count)
    {
        uiController.ChangeHumansCountText(count);
    }

    void RestartAllCounts()
    {
        countEatenHumans = 0;
        countEatenHumansToIncreaseTail = 0;
        countEatenCrystals = 0;
        countOfEatenInRowCrystals = 0;
        SetCountCrystalsToUi(0);
        SetCountHumansToUi(0);
    }

    public void UskToCreatNextBlock()
    {
        blocksGenerator.CreatBlock();
    }
}