using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // [SerializeField] private HumanColor snakeColor = (HumanColor) 5;
    private SnakeTail snakeTail;
    private SnakeControl snakeControl;
    private Renderer _renderer;

    // [SerializeField] Color curentColor = Color.white;
    private GameColors _snakeGameColor = new GameColors(5);

    // Start is called before the first frame update
    void Awake()
    {
        _snakeGameColor = new GameColors(5);
        snakeControl = GetComponent<SnakeControl>();
        snakeTail = GetComponent<SnakeTail>();
        _renderer = GetComponent<Renderer>();
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
        // snakeTail.ChangeColor(gameColor);
    }
}
