using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;
using NaughtyAttributes;
using Unity.Mathematics;

public class TutorialLoad : MonoBehaviour
{

    public Volume TutorialFadePost;
    public CanvasGroup TextShow;
    [SerializeField] private float _fadeTime;
    [SerializeField] private Range range;


    void Awake() {
    }
    // Start is called before the first frame update
    void Start()
    {
        TutorialFadePost.weight = 0f;
        TextShow.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            StartTutorial();
        }
    }

    
    void StartTutorial()
    {
        StartCoroutine(PlayFade());
    }

    IEnumerator PlayFade()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < _fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / _fadeTime;
            TutorialFadePost.weight = Mathf.Lerp(0f,1f, progress);
            yield return null;
        }
        TutorialFadePost.weight = 1f;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        float textElapsedTime = 0.0f;
        while(textElapsedTime < 2f)
        {
            textElapsedTime += Time.deltaTime;
            float progress = textElapsedTime / 2f;
            TextShow.alpha = Mathf.Lerp(0f,1f, progress);
            yield return null;
        }
        TextShow.alpha = 1f;
    }


}
