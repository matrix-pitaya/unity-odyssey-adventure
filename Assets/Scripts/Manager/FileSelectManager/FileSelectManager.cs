using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class FileSelectManager : SingletenMonoBehaviour<FileSelectManager>
{
    [Header("LEVEL CARD PARENT TRANSFORM")]
    [SerializeField] RectTransform contentTransform;

    [Header("LEVEL CARD PREFAB")]
    [SerializeField] GameObject saveCardPrefab;

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        LoadSaveCardData();
    }

    void LoadSaveCardData()
    {
        GameData[] gameDatas = SaveManager.Instance.LoadGameDatas();
        for(int i = 0;i < gameDatas.Length;i++)
        {
            GameObject SaveCardGO = Instantiate(saveCardPrefab, contentTransform);
            SaveCardGO.GetComponent<SaveCardUI>().InitSaveCard(i, gameDatas[i]);
        }
    }
}
