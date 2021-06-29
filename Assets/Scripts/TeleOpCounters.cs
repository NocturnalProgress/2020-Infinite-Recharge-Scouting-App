using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeleOpCounters : MonoBehaviour // This script is used to collect the amount of Power Cells scored during TeleOp
{
    // [HideInInspector]

    public int upperCount;
    public int innerCount;
    public int lowerCount;

    public TMP_Text upperCounter;

    public TMP_Text innerCounter;

    public TMP_Text lowerCounter;

    public Button subtractUpperCounter;

    public Button addUpperCounter;

    public Button subtractInnerCounter;

    public Button addInnerCounter;

    public Button subtractLowerCounter;

    public Button addLowerCounter;

    private void Start()
    {
        upperCount = Convert.ToInt32(upperCounter.text);
        innerCount = Convert.ToInt32(innerCounter.text);
        lowerCount = Convert.ToInt32(lowerCounter.text);
    }

    //Inner
    public void SubtractFromUpperCounter()
    {
        upperCount -= 1;
        UpdateUpperCount();
    }

    public void AddToUpperCounter()
    {
        upperCount += 1;
        UpdateUpperCount();
    }

    //InnerInner
    public void SubtractFromInnerCount()
    {
        innerCount -= 1;
        UpdateInnerCount();
    }

    public void AddToInnerCounter()
    {
        innerCount += 1;
        UpdateInnerCount();
    }

    //Outer
    public void SubtractFromLowerCounter()
    {
        lowerCount -= 1;
        UpdateLowerCount();
    }

    public void AddToLowerCounter()
    {
        lowerCount += 1;
        UpdateLowerCount();
    }

    private void UpdateUpperCount()
    {
        upperCounter.text = upperCount.ToString();
    }

    private void UpdateInnerCount()
    {
        innerCounter.text = innerCount.ToString();
    }

    private void UpdateLowerCount()
    {
        lowerCounter.text = lowerCount.ToString();
    }
}