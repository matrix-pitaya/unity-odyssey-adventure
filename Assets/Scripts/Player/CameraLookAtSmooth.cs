using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtSmooth : MonoBehaviour
{
    Vector3 position;
    const float lockValue = 1f;

    void Update()
    {
        LockAxisY();
    }

    void LockAxisY()
    {
        if(transform.localPosition.y!= lockValue)
        {
            position = transform.localPosition;
            position.y = lockValue;
            transform.localPosition = position;
        }
    }
}
