using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDetail", menuName = "ScriptableObject/Level/Level Detail")]
public class LevelDetailSO : ScriptableObject
{
    [Header("GAME LEVEL DATA INFORMATION")]
    [SerializeField] LevelInformation[] gameLevelDatas;

    public int Count
    {
        get
        {
            return gameLevelDatas.Length;
        }
    }
    public LevelInformation this[int index]
    {
        get
        {
            return gameLevelDatas[index];
        }
    }
}
