using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInCanvas : MonoBehaviour
{
    private Animator animator;
    public GameObject canvas;

    void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(fadeTime());
    }

    IEnumerator fadeTime()
    {
        animator.enabled = true;
        yield return new WaitForSeconds(0.0001f);
        animator.enabled = false;
        yield return new WaitForSeconds(5f);
        animator.enabled = true;
        canvas.GetComponent<GraphicRaycaster>().enabled = true;
        // yield return new WaitForSeconds(1.5f);
        // animator.enabled = false;

    }
}