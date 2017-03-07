using UnityEngine;
using System.Collections;

#pragma warning disable 0414

public class FadeIn : MonoBehaviour
{
    public float fadeTime = 0.25f;
    //public int fadeTransitions = 25;
    private float waitFadeTransition = 0.001f;
    private float fadeSpeed;
    private float alpha;

    public float offsetTime = 0.3f;
    public float startOffset = 0.3f;
    //public int offsetTransitions = 30;
    private float waitOffsetTransition = 0.001f;
    private float stepTranslation;
    private float initialPosition;
    private float currentPosition;

    private GUITexture texture;
    private GUIText text;
    private bool workingWithTexture;
    private bool workingWithText;

    public float alphaTarget = 1.0f;

    void Start()
    {
        if (GetComponent<TextBlinking>() != null)
            GetComponent<TextBlinking>().active = false;

        fadeTime /= 20;
        offsetTime /= 20;

        workingWithText = workingWithTexture = false;

        if (GetComponent<GUITexture>() != null)
        {
            texture = GetComponent<GUITexture>();
            workingWithTexture = true;
        }
        else if (GetComponent<GUIText>() != null)
        {
            text = GetComponent<GUIText>();
            workingWithText = true;
        }

        alpha = 0.0f;
        updateAlpha();
        fadeSpeed = 0.5f / (fadeTime/waitFadeTransition);
        StartCoroutine(Fade());

        initialPosition = GetComponent<Transform>().position.y;
        currentPosition = initialPosition + startOffset;
        updatePosition();
        stepTranslation = startOffset / (offsetTime/waitOffsetTransition);
        StartCoroutine(OffsetMovement());
    }

    IEnumerator Fade()
    {
        while(alpha <= alphaTarget)
        {
            alpha += fadeSpeed;
            updateAlpha();
            yield return new WaitForSeconds(waitFadeTransition);
        }
        if (GetComponent<TextBlinking>() != null)
            GetComponent<TextBlinking>().active = true;
    }

    IEnumerator OffsetMovement()
    {
        if (startOffset > 0)
            while (currentPosition >= initialPosition)
            {
                currentPosition -= stepTranslation;
                updatePosition();
                yield return new WaitForSeconds(waitOffsetTransition);
            }
        else
            while (currentPosition <= initialPosition)
            {
                currentPosition -= stepTranslation;
                updatePosition();
                yield return new WaitForSeconds(waitOffsetTransition);
            }
    }

    private void updateAlpha()
    {
        if (workingWithTexture)
            GetComponent<GUITexture>().color = new Color(
                GetComponent<GUITexture>().color.r,
                GetComponent<GUITexture>().color.g,
                GetComponent<GUITexture>().color.b,
                this.alpha);
        else if (workingWithText)
            GetComponent<GUIText>().color = new Color(
                GetComponent<GUIText>().color.r,
                GetComponent<GUIText>().color.g,
                GetComponent<GUIText>().color.b,
                this.alpha);
    }

    private void updatePosition()
    {
        GetComponent<Transform>().position = new Vector3(
            GetComponent<Transform>().position.x,
            currentPosition,
            GetComponent<Transform>().position.z);
    }

   
}