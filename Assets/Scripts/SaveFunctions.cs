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
        
        //SaveDataContainer charData = new();
        SaveDataHelper dataHelper = new SaveDataHelper(SaveDataContainer.p1Jump, SaveDataContainer.p1Interact, SaveDataContainer.p2Interact, SaveDataContainer.levelsCompleted, SaveDataContainer.elementsActivated);


        formatter.Serialize(stream, dataHelper);
        stream.Close();
    }

    private static void LoadDataIntoDataToSave()
    {
        string path = Application.persistentDataPath + "/SaveGame.orb";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            SaveDataHelper dataHelper = formatter.Deserialize(stream) as SaveDataHelper;
            SaveDataContainer.p1Jump = dataHelper.p1Jump;
            SaveDataContainer.p1Interact = dataHelper.p1Interact;
            SaveDataContainer.p2Interact = dataHelper.p2Interact;
            SaveDataContainer.levelsCompleted = dataHelper.levelsCompleted;
            SaveDataContainer.elementsActivated = dataHelper.elementsActivated;

            stream.Close();
            canLoadData = true;
            //return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            canLoadData = false;
           // return null;
        }
    }

    private void Start()
    {
        dataToSave = GetComponent<DataToSave>();
    }

    [System.Serializable]
    private class SaveDataHelper 
    {
        public KeyCode p1Jump;
        public KeyCode p1Interact;
        public KeyCode p2Interact;

        public bool[] levelsCompleted;

        public bool[] elementsActivated;

        public SaveDataHelper(KeyCode p1Jump, KeyCode p1Interact, KeyCode p2Interact, bool[] levelsCompleted, bool[] elementsActivated)
        {
            this.p1Jump = p1Jump;
            this.p1Interact = p1Interact;
            this.p2Interact = p2Interact;
            this.levelsCompleted = levelsCompleted;
            this.elementsActivated = elementsActivated;
        }
    }
}
