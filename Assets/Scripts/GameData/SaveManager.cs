using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SaveManager : SingletenMonoBehaviour<SaveManager>
{
    [Header("SAVE GAME DATA FILE NAME")]
    [SerializeField] string fileName;
    FileHandler fileHandler;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        InitFileHandler();
    }

    void InitFileHandler()
    {
        fileHandler = new FileHandler(fileName, Application.persistentDataPath);
    }

    public GameData[] LoadGameDatas()
    {
        GameData[] gameDatas = new GameData[Setting.GameDataSlotNum];
        for(int i = 0;i < gameDatas.Length;i++)
        {
            gameDatas[i] = fileHandler.LoadGameData(i);
        }
        return gameDatas;
    }
    public void SaveGameData(GameData gameData,int index)
    {
        fileHandler.SaveGameData(index, gameData);
    }
    public void DeleteGameData(int index)
    {
        fileHandler.DeleteGameData(index);
    }
}
