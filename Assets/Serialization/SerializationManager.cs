using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

/// <summary>
/// 
/// </summary>
public abstract class SerializationManager
{
    private static string defaultPath;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="saveName"></param>
    /// <param name="saveData"></param>
    /// <returns></returns>
    public static bool Save(string saveName, object saveData, bool createBinaryFileAlso = false)
    {

        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves" + saveName + ".json";
        var dataString = CreateJsonStream(saveData);
        File.WriteAllText(Application.persistentDataPath + "/MyJson.json", dataString);
        
        if(createBinaryFileAlso)
        {
            BinaryFormatter formatter = GetBinaryFormatter();
            FileStream file = File.Create(path);
            formatter.Serialize(file, saveData);
            file.Close();
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static object Load(string path)
    {
        if(!File.Exists(path))
        {
            Debug.Log("No file exists at Path: " + path);
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            file.Close();
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter(); 

        return binaryFormatter;
    }

    private static string CreateJsonStream(object obj)
    {
        if(obj == null)  return null;
        
        return JsonUtility.ToJson(obj);
    }
}
