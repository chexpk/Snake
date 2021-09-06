using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private BlocksGenerator blocks;
    [SerializeField] private UIController uiController;

    [SerializeField] Vector3 basePlayerPosition = new Vector3(0, 0, 2.45f);

    private void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RestartByUiButton()
    {
        player.RestartSnake(basePlayerPosition);
        blocks.RestartBlocks();
        uiController.ShowRestartDisplay(false);
    }

    void Restart()
    {

    }

    public void ShowRestartButtonByEvent()
    {
        uiController.ShowRestartDisplay(true);
    }

    public void StartGame()
    {
        uiController.HideStartDisplay();
        RestartByUiButton();
    }
}
