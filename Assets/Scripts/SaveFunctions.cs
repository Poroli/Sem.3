using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFunctions : MonoBehaviour
{
    public static void SaveData(ControlKeys cKeys, MasterControlScript mCS, ElementsManager eManager)
    {
        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/SaveGame.orb";

        FileStream stream = new(path, FileMode.Create);

        DataToSave charData = new(cKeys,mCS,eManager);

        formatter.Serialize(stream, charData);
        stream.Close();
    }

    public static DataToSave LoadData()
    {
        string path = Application.persistentDataPath + "/SaveGame.orb";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            DataToSave data = formatter.Deserialize(stream) as DataToSave;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }
}
