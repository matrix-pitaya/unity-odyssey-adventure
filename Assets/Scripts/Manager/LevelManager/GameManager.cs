using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : SingletenMonoBehaviour<GameManager>
{
    [Header("LEVEL TRANSFORM")]
    [SerializeField] Transform levelTransform;

    [Header("PLAYER INFORMATION")]
    [SerializeField] Player player;

    Transform spawnPoint;
    bool isGamePause;
    bool isGameOver = false;
    float passTime;
    const float loadDelay = 1.25f;

    public Player Player
    {
        get
        {
            return player;
        }
    }
    public Transform SpawnPoint
    {
        get
        {
            return spawnPoint;
        }
        set
        {
            spawnPoint = value;
        }
    }
    public Transform LevelTransform
    {
        get
        {
            return levelTransform;
        }
    }
    public bool IsGamePause
    {
        get
        {
            return isGamePause;
        }
    }
    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
    }
    public float PassTime
    {
        get
        {
            return passTime;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        SetCursorState(false);
        InitCoinsStatrsNum();
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
    void Update()
    {
        UpdataLevelTime();
    }

    void InitCoinsStatrsNum()
    {
        PlayerGameDataManager.Instance.Coins = 0;
        PlayerGameDataManager.Instance.Stars = 0;
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
        ExitLevel();
    }
    void RestarLevelEvent_OnRestarLevel(RestarLevelEvent restarLevelEvent)
    {
        RestartLevel();
    }
    void RestartCheckPointEvent_OnRestartCheckPoint(RestartCheckPointEvent restartCheckPointEvent)
    {
        RestartCheckPoint();
    }
    void PauseGame()
    {
        isGamePause = true;
        Time.timeScale = 0;
        SetCursorState(true);
    }
    void ResumeGame()
    {
        isGamePause = false;
        Time.timeScale = 1;
        SetCursorState(false);
    }
    void RestartLevel()
    {
        isGameOver = true;
        Time.timeScale = 1;
        SetCursorState(false);
    }
    void RestartCheckPoint()
    {
        StartCoroutine(RestartCheckPointCoroutine());
    }
    void ExitLevel()
    {
        isGameOver = true;
        Time.timeScale = 1;
        SetCursorState(true);
    }
    void UpdataLevelTime()
    {
        if(!isGameOver && !isGamePause)
        {
            passTime += Time.deltaTime;
            UIManager.Instance.UpdataPassTime(passTime);
        }
    }
    void SetCursorState(bool isUnLocked)
    {
#if UNITY_STANDALONE
        Cursor.visible = isUnLocked;
        Cursor.lockState = isUnLocked ? CursorLockMode.None : CursorLockMode.Locked;
#endif
    }

    public void OnPause()
    {
        UIManager.Instance.OpenButton();
        GameEventManager.Instance.PauseEvent.CallPauseEvent();
    }
    public void OnResume()
    {
        UIManager.Instance.CloseButton();
        GameEventManager.Instance.ResumeEvent.CallResumeEvent();
    }
    public void OnRestartCheckPoint()
    {
        GameEventManager.Instance.RestartCheckPointEvent.CallRestartCheckPointEvent();
    }
    public void OnRestartLevel()
    {
        GameEventManager.Instance.RestarLevelEvent.CallRestarLevelEvent();
        SceneLoader.Instance.ReLoad();
    }
    public void OnExitLevel()
    {
        GameEventManager.Instance.ExitLevelEvent.CallExitLevelEvent();
        SceneLoader.Instance.LoadScene(Setting.LevelSelectScene);
    }

    IEnumerator RestartCheckPointCoroutine()
    {
        ResumeGame();
        isGameOver = true;
        SceneLoader.Instance.PlayLoadingAnimation(true);
        yield return new WaitForSeconds(loadDelay);
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
        isGameOver = false;
        SceneLoader.Instance.PlayLoadingAnimation(false);
    }
}
