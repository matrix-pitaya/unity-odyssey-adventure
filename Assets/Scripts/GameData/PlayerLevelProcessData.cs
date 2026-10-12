using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerLevelProcessData
{
    public PlayerLevelProcessData()
    {
        coins = 0;
        starts = 0;
        time = 0;
    }

    public int starts;
    public int coins;
    public float time;
}
