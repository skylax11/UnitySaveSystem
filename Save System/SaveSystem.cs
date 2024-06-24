using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System;

public static class SaveSystem
{
    private static string pathBinary = Application.persistentDataPath + "/player.bin";
    private static string pathJSON = Application.persistentDataPath + "/player.json";


    /// <param name="data"> The data which will be saved </param>
    public static void SaveDatasBinary(Datas data)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = new FileStream(pathBinary, FileMode.Create);

        binaryFormatter.Serialize(file, data);
        file.Close();
    }
    public static Datas LoadDatasBinary()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream file = null; // Firstly, File was setted as null because avoid encountering compile error (if içerisinde deðeri atanmamýþ bir þeyin null kontrolü olamaz.)
        try
        {
            file = new FileStream(pathBinary, FileMode.Open);
        }
        catch(Exception ex)
        {
            if (file == null)
            {
                Debug.LogWarning("No file found");
                return null;
            }
        }
        
        var readData = binaryFormatter.Deserialize(file) as Datas;
        file.Close();
        return readData;
    }
    /// <param name="data"> The data which will be saved </param>
    public static void SaveDatasJSON(Datas data)
    {
        var theJSON = JsonUtility.ToJson(data);
        File.WriteAllText(pathJSON, theJSON);
    }
    public static Datas LoadDatasJSON()
    {
        var jsonData = File.ReadAllText(pathJSON);
        var readData = JsonUtility.FromJson<Datas>(jsonData);
        return readData;
    }
}
