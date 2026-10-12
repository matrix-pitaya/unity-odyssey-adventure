using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCardUI : MonoBehaviour
{
    [Header("START SLOT INFORMATION")]
    [SerializeField] Image[] starts;

    [Header("SCENE DETAILS INFORMATION")]
    [SerializeField] Text title;
    [SerializeField] Text Description;
    [SerializeField] Image icon;

    [Header("PLAYER BEST TIME")]
    [SerializeField] Text bestTime;

    [Header("PLAYER COLLECT COIN NUM")]
    [SerializeField] Text coinNum;

    [Header("PLAY BUTTON")]
    [SerializeField] Button playButton;

    LevelInformation levelInformation;
    string sceneName;
    int index;

    void Awake()
    {
        BuildButtonListener();
    }

    void BuildButtonListener()
    {
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(StartLevel);
    }
    void StartLevel()
    {
        PlayerGameDataManager.Instance.PlayerLevelProcessData = PlayerGameDataManager.Instance.PlayerCurrentGameData.levels[index];
        PlayerGameDataManager.Instance.LevelCardIndex = index;
        PlayerGameDataManager.Instance.Retries = Setting.PlayerDefaultRetrieNum;
        SceneLoader.Instance.LoadScene(sceneName);
        AudioManager.Instance.PlayUIConfirmAudioClip();
    }

    public void InitLevelCard(LevelInformation levelInformation, PlayerLevelProcessData playerLevelProcessData,int index)
    {
        this.levelInformation = levelInformation;
        this.index = index;
        sceneName = this.levelInformation.SceneName;
        title.text = this.levelInformation.Name;
        Description.text = this.levelInformation.Description;
        icon.sprite = this.levelInformation.Icon;
        foreach(var start in  starts)
        {
            start.enabled = false;
        }
        UpdataUI(playerLevelProcessData);
    }
    public void UpdataUI(PlayerLevelProcessData playerLevelProcessData)
    {
        for(int i = 0; i < playerLevelProcessData.starts; i++)
        {
            starts[i].enabled = true;
        }
        coinNum.text = playerLevelProcessData.coins.ToString();
        bestTime.text = Utility.TimeTransmit(playerLevelProcessData.time);
    }
}
