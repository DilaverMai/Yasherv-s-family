using System;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{
    [Button]
    public void Test()
    {
        SpeechGirl?.Invoke(0);
    }
    
    public List<string> Speeches;

    public static Action<int> SpeechGirl;
    public CanvasGroup SpeechImage;
    public TextMeshProUGUI SpeechText;

    private void Start()
    {
        SpeechImage.alpha = 0;
    }

    private void OnEnable()
    {
        SpeechGirl += OnSpeechGirl;
    }
    
    private void OnDisable()
    {
        SpeechGirl -= OnSpeechGirl;
    }

    private void OnSpeechGirl(int obj)
    {
        SpeechText.text = Speeches[obj];
        SpeechImage.DOFade(1, 0.5f).OnComplete(
            ()=>
            {
                SpeechImage.DOFade(0, 0.5f).SetDelay(2f).SetId("SpeechImage");
            }
            ).SetId("SpeechImage");
    }
}
