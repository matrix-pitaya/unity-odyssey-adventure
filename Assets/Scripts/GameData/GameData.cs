using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public GameData(int levelCount)
    {
        retries = Setting.PlayerDefaultRetrieNum;
        starts = 0;
        coins = 0;
        createTime = System.DateTime.UtcNow.ToString();
        updataTime = System.DateTime.UtcNow.ToString();
        levels = new PlayerLevelProcessData[levelCount];
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = new PlayerLevelProcessData();
        }
    }

    public PlayerLevelProcessData[] levels;
    public int retries;
    public int starts;
    public int coins;
    public string createTime;
    public string updataTime;
}
