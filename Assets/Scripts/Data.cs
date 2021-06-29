using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Data : MonoBehaviour // Allows data to be accesed by GenerateQRCode.cs or SerializeData.cs
{
    public AutonomousCounters autonomousCounters;
    public TeleOpCounters teleOpCounters;
    public TMP_InputField nameInputField;
    public TMP_InputField teamNameInputField;
    public TMP_InputField matchNumberInputField;
    public TMP_InputField additionalNotesInputField;
    public TMP_Dropdown initiationLineDropDown;
    public TMP_Dropdown drivingEffectivenessDropDown;
    public TMP_Dropdown defenseEffectivenessDropDown;
    public TMP_Dropdown climbingEffectivenssDropDown;
    [HideInInspector] public string data;
    public NotificationSystem notificationSystem;

    [SerializeField]
    public List<DataToExport> scoutingDataContainer = new List<DataToExport>();

    public DataToExport dataToExport = new DataToExport();

    public void AddToJsonList()
    {
        dataToExport.name = nameInputField.text;
        dataToExport.teamName = teamNameInputField.text;
        dataToExport.matchNumber = matchNumberInputField.text;
        dataToExport.initiationLine = initiationLineDropDown.options[initiationLineDropDown.value].text.ToString();

        dataToExport.autonomousUpperCount = autonomousCounters.upperCount.ToString();
        dataToExport.autonomousInnerCount = autonomousCounters.innerCount.ToString();
        dataToExport.autonomousLowerCount = autonomousCounters.lowerCount.ToString();

        dataToExport.teleOpUpperCount = teleOpCounters.upperCount.ToString();
        dataToExport.teleOpInnerCount = teleOpCounters.innerCount.ToString();
        dataToExport.teleOpLowerCount = teleOpCounters.lowerCount.ToString();

        dataToExport.drivingEffectiveness = drivingEffectivenessDropDown.value.ToString();
        dataToExport.defenseEffectiveness = defenseEffectivenessDropDown.value.ToString();
        dataToExport.climbingEffectiveness = climbingEffectivenssDropDown.options[climbingEffectivenssDropDown.value].text;
        dataToExport.additionalNotes = additionalNotesInputField.text;

        scoutingDataContainer.Add(dataToExport);

        int tempNum = Convert.ToInt32(matchNumberInputField.text) + 1;
        matchNumberInputField.text = tempNum.ToString();

        PrepareForNextMatch();
        notificationSystem.FinishedSaving();
    }

    public string SerializeToJson()
    {
        Container container = new Container(scoutingDataContainer);
        string json = JsonUtility.ToJson(container, true);
        Debug.Log(json);
        return json;
    }

    public void PrepareForNextMatch() // Clears the data fields to prepare for the next match
    {
        // Initial Data
        // nameInputField.text = "";
        teamNameInputField.text = "";
        initiationLineDropDown.value = 0;

        // Autonomous
        autonomousCounters.upperCount = 0;
        autonomousCounters.innerCount = 0;
        autonomousCounters.lowerCount = 0;

        autonomousCounters.upperCounter.text = "0";
        autonomousCounters.innerCounter.text = "0";
        autonomousCounters.lowerCounter.text = "0";

        // TeleOp
        teleOpCounters.upperCount = 0;
        teleOpCounters.innerCount = 0;
        teleOpCounters.lowerCount = 0;

        teleOpCounters.upperCounter.text = "0";
        teleOpCounters.innerCounter.text = "0";
        teleOpCounters.lowerCounter.text = "0";

        // End Game
        drivingEffectivenessDropDown.value = 0;
        defenseEffectivenessDropDown.value = 0;
        climbingEffectivenssDropDown.value = 0;
        additionalNotesInputField.text = "";
    }
}

[System.Serializable]
public class DataToExport
{
    public string name;
    public string matchNumber;
    public string teamName;
    public string initiationLine;
    public string autonomousUpperCount;
    public string autonomousInnerCount;
    public string autonomousLowerCount;
    public string teleOpUpperCount;
    public string teleOpInnerCount;
    public string teleOpLowerCount;
    public string drivingEffectiveness;
    public string defenseEffectiveness;
    public string climbingEffectiveness;
    public string additionalNotes;
}

// Wrapper to allow list to be serialized
[System.Serializable]
public class Container
{
    [SerializeField]
    public List<DataToExport> ScoutingData;

    public Container(List<DataToExport> _dataList)
    {
        ScoutingData = _dataList;
    }
}