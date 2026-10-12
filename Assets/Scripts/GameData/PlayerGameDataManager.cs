using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerGameDataManager : SingletenMonoBehaviour<PlayerGameDataManager>
{
    GameData playerCurrentGameData;
    PlayerLevelProcessData playerLevelProcessData;
    int saveCardIndex;
    int levelCardIndex;
    int retries;
    int coins;
    int stars;

    public GameData PlayerCurrentGameData
    {
        get
        {
            return playerCurrentGameData;
        }
        set
        {
            playerCurrentGameData = value;
        }
    }
    public PlayerLevelProcessData PlayerLevelProcessData
    {
        get
        {
            return playerLevelProcessData;
        }
        set
        {
            playerLevelProcessData = value;
        }
    }
    public int SaveCardIndex
    {
        get
        {
            return saveCardIndex;
        }
        set
        {
            saveCardIndex = value;
        }
    }
    public int LevelCardIndex
    {
        get
        {
            return levelCardIndex;
        }
        set
        {
            levelCardIndex = value;
        }
    }
    public int Retries
    {
        get
        {
            return retries;
        }
        set
        {
            retries = value;
        }
    }
    public int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins = value;
        }
    }
    public int Stars
    {
        get
        {
            return stars;
        }
        set
        {
            stars = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void SaveGameData()
    {
        playerCurrentGameData.updataTime = System.DateTime.UtcNow.ToString();
        if(playerLevelProcessData.time <= 0 || GameManager.Instance.PassTime < playerLevelProcessData.time)
        {
            playerLevelProcessData.time = GameManager.Instance.PassTime;
        }
        if(coins > playerLevelProcessData.coins)
        {
            playerCurrentGameData.coins += (coins - playerLevelProcessData.coins);
            playerLevelProcessData.coins = coins;
        }
        if(stars > playerLevelProcessData.starts)
        {
            playerCurrentGameData.starts += (stars - playerLevelProcessData.starts);
            playerLevelProcessData.starts = stars;
        }
        SaveManager.Instance.SaveGameData(playerCurrentGameData, saveCardIndex);
    }
    public int AddCoins(int num)
    {
        coins += num;
        return coins;
    }
    public int AddStars(int num)
    {
        stars += num;
        return stars;
    }
    public int DecreastRetries(int num)
    {
        retries -= num;
        return retries;
    }
}
