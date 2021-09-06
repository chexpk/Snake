using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text humansCountText;
    [SerializeField] private Text crystalsCountText;
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

}
