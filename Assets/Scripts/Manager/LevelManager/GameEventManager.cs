using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region REQUIRE_COMPONENT
[RequireComponent(typeof(PauseEvent))]
[RequireComponent(typeof(ResumeEvent))]
[RequireComponent(typeof(ExitLevelEvent))]
[RequireComponent(typeof(RestarLevelEvent))]
[RequireComponent(typeof(RestartCheckPointEvent))]
[DisallowMultipleComponent]
#endregion
public class GameEventManager : SingletenMonoBehaviour<GameEventManager>
{
    PauseEvent pauseEvent;
    ResumeEvent resumeEvent;
    ExitLevelEvent exitLevelEvent;
    RestarLevelEvent restarLevelEvent;
    RestartCheckPointEvent restartCheckPointEvent;

    public PauseEvent PauseEvent
    {
        get
        {
            return pauseEvent;
        }
    }
    public ResumeEvent ResumeEvent
    {
        get
        {
            return resumeEvent;
        }
    }
    public ExitLevelEvent ExitLevelEvent
    {
        get
        {
            return exitLevelEvent;
        }
    }
    public RestarLevelEvent RestarLevelEvent
    {
        get
        {
            return restarLevelEvent;
        }
    }
    public RestartCheckPointEvent RestartCheckPointEvent
    {
        get
        {
            return restartCheckPointEvent;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        LoadComponent();
    }
    void LoadComponent()
    {
        pauseEvent = gameObject.GetComponent<PauseEvent>();
        resumeEvent = gameObject.GetComponent<ResumeEvent>();
        exitLevelEvent = gameObject.GetComponent<ExitLevelEvent>();
        restarLevelEvent = gameObject.GetComponent<RestarLevelEvent>();
        restartCheckPointEvent = gameObject.GetComponent<RestartCheckPointEvent>();
    }
}
