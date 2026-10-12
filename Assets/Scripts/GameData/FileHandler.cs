using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class FileHandler
{
    string fileName;
    string fileDir;

    public FileHandler(string fileName, string fileDir)
    {
        this.fileName = fileName;
        this.fileDir = fileDir;
    }
    public GameData LoadGameData(int index)
    {
        string fillPath = Path.Combine(fileDir, fileName);
        fillPath += $"_{index}";
        if (File.Exists(fillPath))
        {
            try
            {
                string jsonData = null;
                using (FileStream fileStream = new FileStream(fillPath,FileMode.Open))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        jsonData = streamReader.ReadToEnd();
                    }
                }
                return JsonUtility.FromJson<GameData>(jsonData);
            }
            catch(Exception e)
            {
                Debug.LogError("Error On Trying To Load Game Data From File " + fillPath + " Error:" + e);
                return null;
            }
        }
        return null;
    }
    public void SaveGameData(int index, GameData gameData)
    {
        string fillPath = Path.Combine(fileDir, fileName);
        fillPath += $"_{index}";
        try
        {
            if(!Directory.Exists(fillPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fillPath));
            }
            string jsonData = JsonUtility.ToJson(gameData, true);
            using (FileStream fileStream = new FileStream(fillPath,FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(jsonData);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error On Trying To Save Game Data From File " + fillPath + " Error:" + e);
        }
    }
    public void DeleteGameData(int index)
    {
        string fillPath = Path.Combine(fileDir, fileName);
        fillPath += $"_{index}";
        if (File.Exists(fillPath))
        {
            File.Delete(fillPath);
        }
    }
}
