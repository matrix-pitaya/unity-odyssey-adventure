using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class SaveCardUI : MonoBehaviour
{
    [Header("GAME LEVEL CARD SAVE DATA INFORMATION")]
    [SerializeField] Text retriesNum;
    [SerializeField] Text startsNum;
    [SerializeField] Text coinsNum;
    [SerializeField] Text updataTime;
    [SerializeField] Text createTime;

    [Header("GAME LEVEL CARD DATA CHOOSE")]
    [SerializeField] GameObject dataGO;
    [SerializeField] GameObject emptyGO;

    [Header("GAME LEVEL CARD BUTTON INFORMATION")]
    [SerializeField] Button load;
    [SerializeField] Button delete;
    [SerializeField] Button create;

    int index;
    bool isFillData;
    GameData gameData;

    void Awake()
    {
        BlindButtonListener();
    }

    void BlindButtonListener()
    {
        load.onClick.RemoveAllListeners();
        delete.onClick.RemoveAllListeners();
        create.onClick.RemoveAllListeners();
        load.onClick.AddListener(Load);
        delete.onClick.AddListener(Delete);
        create.onClick.AddListener(Create);
    }
    void UpdataUI()
    {
        isFillData = gameData != null;
        dataGO.SetActive(isFillData);
        emptyGO.SetActive(!isFillData);
        load.interactable = isFillData;
        delete.interactable = isFillData;
        create.interactable = !isFillData;
        if (isFillData)
        {
            retriesNum.text = gameData.retries.ToString();
            startsNum.text = gameData.starts.ToString();
            coinsNum.text = gameData.coins.ToString();
            updataTime.text = DateTime.Parse(gameData.updataTime).ToLocalTime().ToString(Setting.DateFront);
            createTime.text = DateTime.Parse(gameData.createTime).ToLocalTime().ToString(Setting.DateFront);
        }
    }

    public void InitSaveCard(int index,GameData gameData)
    {
        this.index = index;
        this.gameData = gameData;
        UpdataUI();
    }

    void Load()
    {
        PlayerGameDataManager.Instance.PlayerCurrentGameData = gameData;
        PlayerGameDataManager.Instance.SaveCardIndex = index;
        SceneLoader.Instance.LoadScene(Setting.LevelSelectScene);
        AudioManager.Instance.PlayUIConfirmAudioClip();
    }
    void Delete()
    {
        SaveManager.Instance.DeleteGameData(index);
        gameData = null;
        UpdataUI();
        AudioManager.Instance.PlayUIConfirmAudioClip();
    }
    void Create()
    {
        gameData = new GameData(GameResourceManager.Instance.LevelDetail.Count);
        SaveManager.Instance.SaveGameData(gameData, index);
        UpdataUI();
        AudioManager.Instance.PlayUIConfirmAudioClip();
    }
}
