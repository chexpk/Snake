using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("GameCountsDisplay")]
    [SerializeField] private Text humansCountText;
    [SerializeField] private Text crystalsCountText;
    [SerializeField] private GameObject humansCountGO;
    [SerializeField] private GameObject crystalsCountGO;

    [Header("RestartDisplay")]
    [SerializeField] private GameObject restartButtonGO;
    [SerializeField] private GameObject totalGO;
    [SerializeField] private Text humansTotalCount;
    [SerializeField] private Text crystalsTotalCount;

    [Header("StartDisplay")]
    [SerializeField] private GameObject startGO;

    // [SerializeField] private Text totalText;
    private int humans = 0;
    private int crystals = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHumansCountText(int count)
    {
        humansCountText.text = count.ToString();
        humans = count;
    }

    public void ChangeCrystalsCountText(int count)
    {
        crystalsCountText.text = count.ToString();
        crystals = count;
    }


    public void ShowRestartDisplay(bool show)
    {
        if (show)
        {
            humansTotalCount.text = humans.ToString();
            crystalsTotalCount.text = crystals.ToString();
            totalGO.SetActive(show);
            restartButtonGO.SetActive(show);
            ShowGameDisplayCounts(!show);
        }
        else
        {
            totalGO.SetActive(show);
            restartButtonGO.SetActive(show);
            ShowGameDisplayCounts(!show);
        }
    }

    void ShowGameDisplayCounts(bool show)
    {
        humansCountGO.SetActive(show);
        crystalsCountGO.SetActive(show);
    }

    public void HideStartDisplay()
    {
        startGO.SetActive(false);
    }

}
