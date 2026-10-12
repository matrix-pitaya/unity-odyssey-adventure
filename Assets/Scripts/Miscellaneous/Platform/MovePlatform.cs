using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathControl))]
[DisallowMultipleComponent]
public class MovePlatform : MonoBehaviour
{
    PathControl pathControl;
    const float waitTime = 2.0f;
    const float moveSpeed = 3.0f;
    bool isPlayerOnPlatform;

    void Awake()
    {
        LoadComponent();
    }
    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    void LoadComponent()
    {
        pathControl = gameObject.GetComponent<PathControl>();
    }

    IEnumerator MoveCoroutine()
    {
        while(true)
        {
            Vector3 nextPosition = Vector3.MoveTowards(gameObject.transform.position, pathControl.TargetPosition, moveSpeed * Time.fixedDeltaTime);
            if (isPlayerOnPlatform)
            {
                GameManager.Instance.Player.gameObject.transform.position += nextPosition - gameObject.transform.position;
            }
            gameObject.transform.position = nextPosition;
            if (pathControl.IsArriveCurrentPathPoint)
            {
                pathControl.ToNextPathPoint();
                yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForFixedUpdate();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(Setting.Player))
        {
            isPlayerOnPlatform = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(Setting.Player))
        {
            isPlayerOnPlatform = false;
        }
    }
}
