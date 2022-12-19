using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFunctions : MonoBehaviour
{
    public static void SaveData(ElementsManager eManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveGame.orb";

        FileStream stream = new FileStream(path, FileMode.Create);

        DataToSave charData = new DataToSave(eManager);

        formatter.Serialize(stream, charData);
        stream.Close();
    }

    public static DataToSave LoadData()
    {
        string path = Application.persistentDataPath + "/SaveGame.orb";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

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
