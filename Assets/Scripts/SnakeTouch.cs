using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTouch : MonoBehaviour
{
    private Player player;
    GameColors _lineGameColor;
    private bool isFever = false;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void SetIsFever(bool fever)
    {
        isFever = fever;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("ObjectOnRoad"))
        {
            if (IsEatable(other.gameObject) || isFever)
            {
                // Destroy(other.gameObject);
                other.gameObject.SetActive(false);
            }
            else
            {
                SnakeCrashed();
            }
            return;
        }

        if (other.CompareTag("colorLine"))
        {
            var colorLine = other.gameObject.GetComponent<ColorLine>();
            _lineGameColor = colorLine.GetColor();
            player.SetSnakeColor(_lineGameColor);

            CreatNextBlock();
        }
    }

    bool IsEatable(GameObject go)
    {
        //check typ, color
        //"if" for crystals (need sum of last eaten crystals)
        ObjectOnRoad objectOnRoad = go.GetComponent<ObjectOnRoad>();
        switch (GetObjectType(objectOnRoad))
        {
            case "human":
                if (IsSameColorAsSnake(objectOnRoad) || isFever)
                {
                    IncreaseCountEatenHumans();
                    return true;
                }
                return false;
            case "crystal":
                IncreaseCountEatenCrystals();
                return true;
            case "trap":
                return false;
        }
        return false;
    }

    string GetObjectType(ObjectOnRoad objectOnRoad)
    {
        return objectOnRoad.GetObjectType().ToString();
    }

    int GetIndexOfHumanColor(ObjectOnRoad objectOnRoad)
    {
        return objectOnRoad.GetIndexOfHumanColor();
    }

    int GetIndexOfCurrentColor()
    {
        return player.GetCurrentColor().GetIndexOfColor();
    }

    bool IsSameColorAsSnake(ObjectOnRoad objectOnRoad)
    {
        if (GetIndexOfHumanColor(objectOnRoad) == GetIndexOfCurrentColor())
        {
            return true;
        }
        return false;
    }

    void IncreaseCountEatenHumans()
    {
        player.IncreaseCountEatenHumans();
    }
    void IncreaseCountEatenCrystals()
    {
        player.IncreaseCountEatenCrystals();
    }

    void CreatNextBlock()
    {
        player.UskToCreatNextBlock();
    }

    void SnakeCrashed()
    {
        player.SnakeCrashed();
    }
}
