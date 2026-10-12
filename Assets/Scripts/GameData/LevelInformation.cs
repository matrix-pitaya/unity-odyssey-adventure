using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelInformation
{
    [Header("LAEVEL SCENE NAME")]
    [SerializeField] string sceneName;

    [Header("LEVEL INFORMATION")]
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] Sprite icon;

    public string SceneName
    {
        get
        {
            return sceneName;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
    }
    public string Description
    {
        get
        {
            return description;
        }
    }
    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }
}
