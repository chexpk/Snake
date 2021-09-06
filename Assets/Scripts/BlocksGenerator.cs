using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlocksGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> allPrefabsBlocks = new List<GameObject>();
    [SerializeField] private float blockSizeY = 360f;
    [SerializeField] private Vector3 basePositionToFirstSpawn = new Vector3(0, 110, 0);
    private Vector3 lastBlockPosition;
    [SerializeField] private List<GameObject> allExistBlocks = new List<GameObject>();


    private void Awake()
    {

    }

    void CreatFirstBlock()
    {
        var goBlock = Instantiate(allPrefabsBlocks[0], basePositionToFirstSpawn, Quaternion.identity);
        SetLastPositionOfSpawn(basePositionToFirstSpawn);
        allExistBlocks.Add(goBlock);
    }
    public void CreatBlock()
    {
        DestroyOldBlock();
        int lengthEnum = allPrefabsBlocks.Count();
        int randomNum = Random.Range(0, lengthEnum);
        var goBlock = Instantiate(allPrefabsBlocks[randomNum], GetPositionToSpawn(), Quaternion.identity);
        SetLastPositionOfSpawn(GetPositionToSpawn());
        allExistBlocks.Add(goBlock);
    }

    Vector3 GetPositionToSpawn()
    {
        Debug.Log(lastBlockPosition);
        return new Vector3(lastBlockPosition.x, lastBlockPosition.y + (blockSizeY / 2), lastBlockPosition.z);
    }

    void SetLastPositionOfSpawn(Vector3 position)
    {
        lastBlockPosition = position;
    }

    public void RestartBlocks()
    {
        foreach (var block in allExistBlocks)
        {
            Destroy(block);
        }

        allExistBlocks = new List<GameObject>();
        CreatFirstBlock();
    }

    void DestroyOldBlock()
    {
        if (allExistBlocks.Count > 2)
        {
            Destroy(allExistBlocks[0]);
        }
    }
}