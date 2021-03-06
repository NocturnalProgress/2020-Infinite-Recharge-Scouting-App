﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadScoutingData : MonoBehaviour
{
    public SortedDictionary<string, string> scoutingDataFiles = new SortedDictionary<string, string>();

    public GameObject scoutingDataPrefab;
    public GameObject scrollViewContent;

    public NotificationSystem notificationSystem;

    private TextAsset jsonFile;

    public void LoadFiles() // Loads all scouting data files
    {
        foreach (Transform child in scrollViewContent.transform) // Removes all scouting data from the scrollview
        {
            Destroy(child.gameObject);
        }

        scoutingDataFiles.Clear();

        foreach (string filePath in Directory.GetFiles(Application.persistentDataPath)) // This function adds all scouting data to a list
        {
            if (Path.GetFileName(filePath).Contains("ScoutingData"))
            {
                jsonFile = new TextAsset(File.ReadAllText(filePath));
                scoutingDataFiles.Add(Path.GetFileName(filePath), filePath);
            }
        }

        foreach (KeyValuePair<string, string> scoutingData in scoutingDataFiles) // Once the scouting data is loaded, a prefab will be generated for each scouting data that is loaded
        {
            // Debug.Log("Key: " + scoutingData.Key);
            // Debug.Log("Value: " + scoutingData.Value);

            GameObject scoutingDataGameObject = Instantiate(scoutingDataPrefab, scrollViewContent.transform, false) as GameObject;
            PrefabScript prefabScript = scoutingDataGameObject.GetComponent<PrefabScript>();
            prefabScript.transform.name = scoutingData.Key;
            prefabScript.fileName.GetComponentInChildren<TMP_Text>().text = scoutingData.Key;
            prefabScript.timeCreated.GetComponentInChildren<TMP_Text>().text = File.GetCreationTime(scoutingData.Value).ToString();
            prefabScript.fileName.onClick.AddListener(OpenShareMenu);
            prefabScript.timeCreated.onClick.AddListener(OpenShareMenu);
            prefabScript.deleteButton.onClick.AddListener(DeleteFile);
        }
    }

    public void OpenShareMenu() // This function is called whenever one of the buttons besides "Delete" is pressed
    {
        StartCoroutine(ShareFile());
    }

    public void DeleteFile() // This function deletes a scouting data file
    {
        notificationSystem.DeletedScoutingData(EventSystem.current.currentSelectedGameObject.transform.parent.name);
        // Debug.Log("Deleted: " + EventSystem.current.currentSelectedGameObject.transform.parent.name);
        File.Delete(Application.persistentDataPath + "/" + EventSystem.current.currentSelectedGameObject.transform.parent.name);
        Destroy(EventSystem.current.currentSelectedGameObject.transform.parent.gameObject);
        scoutingDataFiles.Remove(EventSystem.current.currentSelectedGameObject.transform.parent.name);
    }

    private IEnumerator ShareFile() // This opens the IOS share menu to allow AirDropping
    {
        yield return new WaitForEndOfFrame();

        // Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        // ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        // ss.Apply();

        // string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        // File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        // Destroy(ss);

        new NativeShare().AddFile(Application.persistentDataPath + "/" + EventSystem.current.currentSelectedGameObject.transform.parent.name)
            .SetSubject("Scouting Data")
            // .SetText("Hello world!")
            // .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
    }
}