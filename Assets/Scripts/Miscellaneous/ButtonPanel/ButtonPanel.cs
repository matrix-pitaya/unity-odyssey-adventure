using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveObject))]
public class ButtonPanel : MonoBehaviour
{
    MoveObject moveObject;
    int inTriggerNum = 0;

    void Awake()
    {
        LoadComponent();
    }
    void LoadComponent()
    {
        moveObject = gameObject.GetComponent<MoveObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Setting.Player) || other.gameObject.CompareTag(Setting.TagCrate))
        {
            inTriggerNum++;
            if(inTriggerNum <= 1)
            {
                moveObject.MoveToTarget();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Setting.Player) || other.gameObject.CompareTag(Setting.TagCrate))
        {
            inTriggerNum--;
            if (inTriggerNum <= 0)
            {
                moveObject.MoveToRecover();
            }
        }
    }
}
