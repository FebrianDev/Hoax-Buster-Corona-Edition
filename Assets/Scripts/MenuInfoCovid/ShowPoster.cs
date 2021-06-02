using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPoster : MonoBehaviour
{

    [SerializeField] private Animator anim;

    private void Start()
    {
        anim.gameObject.SetActive(false);
    }

    public void PosterClick()
    {
        anim.gameObject.SetActive(true);
        StartCoroutine(FadeInActive());
    }

    public void Close()
    {
        StartCoroutine(FadeOutActive());
    }

    IEnumerator FadeInActive()
    {
        anim.SetBool("FadeIn", true);
        anim.SetBool("FadeOut", false);
        yield return new WaitForSeconds(1);
        anim.SetBool("FadeIn", false);
        anim.SetBool("FadeOut", false);
    }

    IEnumerator FadeOutActive()
    {
        anim.SetBool("FadeIn", false);
        anim.SetBool("FadeOut", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("FadeIn", false);
        anim.SetBool("FadeOut", false);
        anim.gameObject.SetActive(false);
    }
    
}
