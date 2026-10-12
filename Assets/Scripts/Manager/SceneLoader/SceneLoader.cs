using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[DisallowMultipleComponent]
public class SceneLoader : SingletenMonoBehaviour<SceneLoader>
{
    [Header("LOAD SCREEN ANIMATOR")]
    [SerializeField] Animator animator;

    bool isLoading = false;
    const float sceneLoadDelay = 1.0f;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        animator.SetTrigger(Setting.Hide);
    }

    public void ReLoad()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadScene(string sceneName)
    {
        if(!isLoading)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }
    }
    public void PlayLoadingAnimation(bool value)
    {
        if(value)
        {
            animator.SetTrigger(Setting.Show);
        }
        else
        {
            animator.SetTrigger(Setting.Hide);
        }
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        isLoading = true;
        animator.SetTrigger(Setting.Show);
        yield return new WaitForSeconds(sceneLoadDelay);
        var operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = true;
        while (!operation.isDone)
        {
            yield return null;
        }
        yield return new WaitForSeconds(sceneLoadDelay);
        isLoading = false;
        animator.SetTrigger(Setting.Hide);
    }
}
