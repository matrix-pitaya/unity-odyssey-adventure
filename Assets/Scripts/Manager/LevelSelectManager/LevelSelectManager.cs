using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class LevelSelectManager : SingletenMonoBehaviour<LevelSelectManager>
{
    [Header("CONTENT TRANSFORM")]
    [SerializeField] RectTransform contentTransform;

    [Header("LEVEL CARD PREFAB")]
    [SerializeField] GameObject levelCardPrefab;

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        InitLevelSelectCard();
    }

    void InitLevelSelectCard()
    {
        int levelCount = GameResourceManager.Instance.LevelDetail.Count;
        for(int i = 0;i < levelCount;i++)
        {
            GameObject levelCard = Instantiate(levelCardPrefab, contentTransform);
            levelCard.GetComponent<LevelCardUI>().InitLevelCard(GameResourceManager.Instance.LevelDetail[i],
                PlayerGameDataManager.Instance.PlayerCurrentGameData.levels[i], i);
        }
    }

    public void BackFileSelect()
    {
        SceneLoader.Instance.LoadScene(Setting.FileSelectScene);
    }
}
