using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class UIManager : SingletenMonoBehaviour<UIManager>
{
    [Header("PLAYER HUD UI INFORMATION")]
    [SerializeField] GameObject HUD;
    [SerializeField] Text hearts;
    [SerializeField] Text retires;
    [SerializeField] Text coins;
    [SerializeField] Text time;
    [SerializeField] Image[] starts;

    [Header("PAUSE UI INFORMATION")]
    [SerializeField] GameObject pause;
    [SerializeField] Animator pauseAnimator;
    [SerializeField] Button resumeButton;
    [SerializeField] Button restartCheckPointButton;
    [SerializeField] Button restartLevelButton;
    [SerializeField] Button exitLevelButton;

    protected override void Awake()
    {
        base.Awake();
        InitAnimator();
        InitButton();
    }
    void OnEnable()
    {
        GameEventManager.Instance.PauseEvent.OnPause += PauseEvent_OnPause;
        GameEventManager.Instance.ResumeEvent.OnResume += ResumeEvent_OnResume;
        GameEventManager.Instance.ExitLevelEvent.OnExitLevel += ExitLevelEvent_OnExitLevel;
        GameEventManager.Instance.RestarLevelEvent.OnRestarLevel += RestarLevelEvent_OnRestarLevel;
        GameEventManager.Instance.RestartCheckPointEvent.OnRestartCheckPoint += RestartCheckPointEvent_OnRestartCheckPoint;
    }
    void OnDisable()
    {
        GameEventManager.Instance.PauseEvent.OnPause -= PauseEvent_OnPause;
        GameEventManager.Instance.ResumeEvent.OnResume -= ResumeEvent_OnResume;
        GameEventManager.Instance.ExitLevelEvent.OnExitLevel -= ExitLevelEvent_OnExitLevel;
        GameEventManager.Instance.RestarLevelEvent.OnRestarLevel -= RestarLevelEvent_OnRestarLevel;
        GameEventManager.Instance.RestartCheckPointEvent.OnRestartCheckPoint -= RestartCheckPointEvent_OnRestartCheckPoint;
    }
    void Start()
    {
        UpdataLevelData();
    }

    void InitAnimator()
    {
        pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        pauseAnimator.SetTrigger(Setting.Hide);
    }
    void InitButton()
    {
        RemoveAllButtonListeners();
        AddButtonListener();
        CloseButton();
    }
    void RemoveAllButtonListeners()
    {
        resumeButton.onClick.RemoveAllListeners();
        restartCheckPointButton.onClick.RemoveAllListeners();
        restartLevelButton.onClick.RemoveAllListeners();
        exitLevelButton.onClick.RemoveAllListeners();
    }
    void AddButtonListener()
    {
        resumeButton.onClick.AddListener(Resume);
        restartCheckPointButton.onClick.AddListener(RestartCheckPoint);
        restartLevelButton.onClick.AddListener(RestartLevel);
        exitLevelButton.onClick.AddListener(ExitLevel);
    }
    void Resume()
    {
        GameManager.Instance.OnResume();
        AudioManager.Instance.PlayUIConfirmAudioClip();
    }
    void RestartCheckPoint()
    {
        GameManager.Instance.OnRestartCheckPoint();
        AudioManager.Instance.PlayUIConfirmAudioClip();
    }
    void RestartLevel()
    {
        GameManager.Instance.OnRestartLevel();
        AudioManager.Instance.PlayUIConfirmAudioClip();
    }
    void ExitLevel()
    {
        GameManager.Instance.OnExitLevel();
        AudioManager.Instance.PlayUIConfirmAudioClip();
    }
    void UpdataLevelData()
    {
        UpdataHeartsNumUI(Setting.PlayerDefaulHurtNum);
        UpdataRetiresNumUI(PlayerGameDataManager.Instance.Retries);
        UpdataCoinsNumUI(PlayerGameDataManager.Instance.Coins);
        UpdataStartsUI();
    }

    void PauseEvent_OnPause(PauseEvent pauseEvent)
    {
        PauseGame();
    }
    void ResumeEvent_OnResume(ResumeEvent resumeEvent)
    {
        ResumeGame();
    }
    void ExitLevelEvent_OnExitLevel(ExitLevelEvent exitLevelEvent)
    {
        ResumeGame();
    }
    void RestarLevelEvent_OnRestarLevel(RestarLevelEvent restarLevelEvent)
    {
        ResumeGame();
    }
    void RestartCheckPointEvent_OnRestartCheckPoint(RestartCheckPointEvent restartCheckPointEvent)
    {
        ResumeGame();
    }
    void PauseGame()
    {
        pauseAnimator.ResetTrigger(Setting.Hide);
        pauseAnimator.SetTrigger(Setting.Show);
    }
    void ResumeGame()
    {
        pauseAnimator.ResetTrigger(Setting.Show);
        pauseAnimator.SetTrigger(Setting.Hide);
    }

    public void OpenButton()
    {
        resumeButton.interactable = true;
        restartCheckPointButton.interactable = GameManager.Instance.SpawnPoint != null ? true : false;
        restartLevelButton.interactable = true;
        exitLevelButton.interactable = true;
    }
    public void CloseButton()
    {
        resumeButton.interactable = false;
        restartCheckPointButton.interactable = false;
        restartLevelButton.interactable = false;
        exitLevelButton.interactable = false;
    }

    public void UpdataHeartsNumUI(int num)
    {
        hearts.text = num.ToString();
    }
    public void UpdataRetiresNumUI(int num)
    {
        retires.text = num.ToString();
    }
    public void UpdataCoinsNumUI(int num)
    {
        coins.text = num.ToString();
    }
    public void UpdataStartsUI()
    {
        for (int i = 0; i < PlayerGameDataManager.Instance.Stars; i++)
        {
            starts[i].enabled = true;
        }
    }
    public void UpdataPassTime(float passTime)
    {
        time.text = Utility.TimeTransmit(passTime);
    }
}
