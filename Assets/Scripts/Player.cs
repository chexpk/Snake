using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    private SnakeTail snakeTail;
    private SnakeControl snakeControl;
    private Renderer _renderer;
    private SnakeTouch snakeTouch;
    private GameColors _snakeGameColor;

    [SerializeField] private UIController uiController;
    [SerializeField] private int feverTime = 5;
    [SerializeField] private int countEatenHumans = 0;
    [SerializeField] private int countEatenHumansToIncreaseTail = 0;

    [SerializeField] private int countEatenCrystals = 0;
    [SerializeField] private int countOfEatenInRowCrystals = 0;


    // [SerializeField] private GameObject spawnPointToText;
    [SerializeField] private GameObject increaseCountText;

    // Start is called before the first frame update
    void Awake()
    {
        _snakeGameColor = new GameColors(1);
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
        snakeTail.DestroyTail();
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
        uiController.ChangeHumansCountText(countEatenHumans);
    }

    void CheckIncreaseTail()
    {
        ++countEatenHumansToIncreaseTail;
        if (countEatenHumansToIncreaseTail > 9)
        {
            IncreaseTail();
            countEatenHumansToIncreaseTail = 0;
        }
    }

    public void IncreaseCountEatenCrystals()
    {
        ++countEatenCrystals;
        ++countOfEatenInRowCrystals;
        if (countOfEatenInRowCrystals > 2)
        {
            FeverModeOn();
        }
        uiController.ChangeCrystalsCountText(countEatenCrystals);
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
        // SetCountEatenCrystalsToZero();
    }

    void CreatIncreaseCountText()
    {
        //создаю всплывающий текст
        // var go = Instantiate(Crt);
        // go.transform.SetParent(canvas.transform);

    }

}
