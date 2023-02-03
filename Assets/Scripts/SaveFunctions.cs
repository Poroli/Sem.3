using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFunctions : MonoBehaviour
{
    private DataToSave dataToSave;
    public static bool canLoadData;

    public void Save()
    {
        dataToSave.GetData();
        SaveData();
    }
    public void Load()
    {
        LoadDataIntoDataToSave();
        dataToSave.SyncData();
    }

    public void NewGame()
    {
        Save();
        LoadDataIntoDataToSave();
        for (int i = 0; i < SaveDataContainer.levelsCompleted.Length; i++)
        {
            SaveDataContainer.levelsCompleted[i] = false;
        }
        for (int i = 0; i < SaveDataContainer.elementsActivated.Length; i++)
        {
            SaveDataContainer.elementsActivated[i] = false;
        }
        dataToSave.SyncData();
    }

    private static void SaveData()
    {
        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/SaveGame.orb";

        FileStream stream = new(path, FileMode.Create);
        
        SaveDataContainer charData = new();

        formatter.Serialize(stream, charData);
        stream.Close();
    }

    private static SaveDataContainer LoadDataIntoDataToSave()
    {
        string path = Application.persistentDataPath + "/SaveGame.orb";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            SaveDataContainer data = formatter.Deserialize(stream) as SaveDataContainer;

            stream.Close();
            canLoadData = true;
            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            canLoadData = false;
            return null;
        }
    }

    private void Start()
    {
        dataToSave = GetComponent<DataToSave>();
    }
}
