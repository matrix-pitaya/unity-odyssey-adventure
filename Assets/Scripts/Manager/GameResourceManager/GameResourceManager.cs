using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourceManager : SingletenMonoBehaviour<GameResourceManager>
{
    [Header("LEVEL DETAIL INFORMATION")]
    [SerializeField] LevelDetailSO levelDetail;

    [Header("SMOOTH PHYSICS MATERIAL")]
    [SerializeField] PhysicMaterial smoothPhysicMaterial;

    public LevelDetailSO LevelDetail
    {
        get
        {
            return levelDetail;
        }
    }
    public PhysicMaterial SmoothPhysicMaterial
    {
        get
        {
            return smoothPhysicMaterial;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
