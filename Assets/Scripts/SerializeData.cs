using System.Collections;
using UnityEngine;

/*
    This script exports the Scouting Data to a Json file.
    First it gives each file a random number at the end in order to prevent duplicate files then it saves the file to Application.persistentDataPath.
*/

public class SerializeData : MonoBehaviour
{
    private string jsonPath;

    public Data data;

    public NotificationSystem notificationSystem;

    public void SaveToJson()
    {
        int randomNumber = UnityEngine.Random.Range(00000, 99999);

        jsonPath = Application.persistentDataPath + "/ScoutingData" + randomNumber + ".json";

        string json = data.SerializeToJson();
        System.IO.File.WriteAllText(jsonPath, json);

        notificationSystem.FinishedExportingData();
    }
}