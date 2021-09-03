using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTouch : MonoBehaviour
{
    private Player player;
    GameColors _lineGameColor;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("ObjectOnRoad"))
        {
            // Debug.Log(other.tag);
            if (IsEatable(other.gameObject))
            {
                Destroy(other.gameObject);

                //для теста - убрать
                player.IncreaseTail();
            }
            else
            {
                player.SetIsSnakeMove(false);
            }

            return;
        }

        if (other.CompareTag("colorLine"))
        {
            var colorLine = other.gameObject.GetComponent<ColorLine>();
            _lineGameColor = colorLine.GetColor();
            player.SetSnakeColor(_lineGameColor);
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
                return IsSameColorAsSnake(objectOnRoad);
            case "crystal":
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
        // Debug.Log(GetHumanColor(objectOnRoad));
        // Debug.Log(GetCurrentColor());
        // ColorUtility.TryParseHtmlString(GetCurrentColor(), out var color);
        if (GetIndexOfHumanColor(objectOnRoad) == GetIndexOfCurrentColor())
        {
            return true;
        }
        return false;
    }
}
