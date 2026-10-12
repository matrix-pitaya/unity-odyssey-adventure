using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int value;

    public int Value
    {
        get
        {
            return value;
        }
    }

    public void InitialHealth(int value)
    {
        this.value = value;
    }
    public int DecreaseHealth(int value)
    {
        this.value -= value;
        return this.value;
    }
    public int IncreaseHealth(int value)
    {
        this.value += value;
        return this.value;
    }
}
