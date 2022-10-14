using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save_Functions : MonoBehaviour
{
    public static void SaveData(Elements_Manager e_Manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveGame.orb";

        FileStream stream = new FileStream(path, FileMode.Create);

        Data_to_Save charData = new Data_to_Save(e_Manager);

        formatter.Serialize(stream, charData);
        stream.Close();
    }

    public static Data_to_Save LoadData()
    {
        string path = Application.persistentDataPath + "/SaveGame.orb";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data_to_Save data = formatter.Deserialize(stream) as Data_to_Save;

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
