using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class PathControl : MonoBehaviour
{
    [Header("PATROL PATHS")]
    [SerializeField] List<Transform> paths;

    [Header("PATROL OVER INDEX IS TO ZERO")]
    [SerializeField] bool isOverIndexToZero;
    bool isIncrease;

    int pathsIndex;

    public Vector3 TargetDirection
    {
        get
        {
            return (paths[pathsIndex].position - gameObject.transform.position).normalized;
        }
    }
    public Vector3 TargetPosition
    {
        get
        {
            return paths[pathsIndex].position;
        }
    }
    public bool IsArriveCurrentPathPoint
    {
        get
        {
            return Vector3.Distance(gameObject.transform.position, paths[pathsIndex].position) < Setting.MinDistance;
        }
    }

    void Awake()
    {
        InitPatrolState();
    }
    void InitPatrolState()
    {
        pathsIndex = 0;
        isIncrease = !isOverIndexToZero;
    }

    public void ToNextPathPoint()
    {
        if(isOverIndexToZero)
        {
            pathsIndex++;
            if(pathsIndex >= paths.Count)
            {
                pathsIndex = 0;
            }
        }
        else
        {
            if(isIncrease)
            {
                pathsIndex++;
                if(pathsIndex >= paths.Count)
                {
                    pathsIndex = paths.Count - 1;
                    isIncrease = false;
                }
            }
            else
            {
                pathsIndex--;
                if (pathsIndex < 0)
                {
                    pathsIndex = 0;
                    isIncrease = true;
                }
            }
        }
    }
}
