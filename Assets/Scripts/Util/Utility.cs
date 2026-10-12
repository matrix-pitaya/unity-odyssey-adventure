using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static bool CheckObjectIsEmpty(Object _object,string fileName,Object checkObject)
    {
        if(checkObject == null)
        {
            Debug.Log(fileName + " Is Empty In " + _object.name);
            return true;
        }
        return false;
    }

    public static string TimeTransmit(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60.0f);
        int seconds = Mathf.FloorToInt(time % 60.0f);
        int milliseconds = Mathf.FloorToInt((time * 100.0f) % 100.0f);
        return minutes.ToString("00") + "\"" + seconds.ToString("00") + "\"" + milliseconds.ToString("00");
    }
}
