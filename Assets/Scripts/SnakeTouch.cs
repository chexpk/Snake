using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTouch : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("ObjectOnRoad"))
        {
            Debug.Log(other.tag);

        }
    }

    bool IsEdible(GameObject go)
    {
        //check typ, color
        //"if" for crystals (need sum of last eaten crystals)
        return true;
    }
}
