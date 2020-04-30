using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeAllImage : MonoBehaviour
{
    private Image[] images;
    private TMP_Text[] texts;

    public Animator fadeScreenAnimator;

    public float timeOfFadeOut = 1;
    public float timeOfFadeIn = 1;

    void OnEnable()
    {
        DoFadeIn();
    }

    public void DoFadeOut()
    {
        foreach (Image image in images)
        {
            image.DOFade(0, timeOfFadeOut).OnComplete(() => gameObject.SetActive(false));
        }

        foreach (TMP_Text text in texts)
        {
            text.DOFade(0, timeOfFadeOut);
        }

        fadeScreenAnimator.SetTrigger("Fade");
    }

    private void DoFadeIn()
    {
        images = GetComponentsInChildren<Image>();
        texts = GetComponentsInChildren<TMP_Text>();

        foreach (Image image in images)
        {
            image.DOFade(0, 0);
        }

        foreach (TMP_Text text in texts)
        {
            text.DOFade(0, 0);
        }



        foreach (Image image in images)
        {
            image.DOFade(1, timeOfFadeIn);
        }

        foreach (TMP_Text text in texts)
        {
            text.DOFade(1, timeOfFadeIn);
        }
    }
}
