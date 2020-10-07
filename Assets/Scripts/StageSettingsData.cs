using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StageSetting_1", menuName = "Marie Kondo Challenge/Stage setting", order = 1)]
public class StageSettingsData : ScriptableObject
{

    [SerializeField]
    private int maxJoyValue = 90000;
    public int MaxJoyValue
    {
        get { return maxJoyValue; }
        set { maxJoyValue = value; }
    }

    [SerializeField]
    private int bonusPerRemainingSecond = 500;
    public int BonusPerRemainingSecond
    {
        get { return bonusPerRemainingSecond; }
        set { bonusPerRemainingSecond = value; }
    }

    [SerializeField]
    private int itemsToWin = 50;
    public int ItemsToWin
    {
        get { return itemsToWin; }
        set { itemsToWin = value; }
    }

    [SerializeField]
    private int timeInSeconds = 120;
    public int TimeInSeconds
    {
        get { return timeInSeconds; }
        set { timeInSeconds = value; }
    }

    [SerializeField]
    private float dropInterval = 1;
    public float DropInterval
    {
        get { return dropInterval; }
        set { dropInterval = value; }
    }
}
