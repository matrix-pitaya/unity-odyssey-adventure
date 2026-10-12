using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class StartGameUI : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    Text text;

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        text = gameObject.GetComponent<Text>();
    }
    void ColorGrey()
    {
        text.color = Color.grey;
    }
    void ColorWhite()
    {
        text.color = Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneLoader.Instance.LoadScene(Setting.FileSelectScene);
        AudioManager.Instance.PlayUIConfirmAudioClip();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ColorGrey();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        ColorWhite();
    }
}
