using UnityEngine;
using System.Collections;
public class FadeInMaterial : MonoBehaviour
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
    public float alphaTarget = 1.0f;

    void Start()
    {

        fadeTime /= 20;
        offsetTime /= 20;
        

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
        GetComponent<Renderer>().material.color = new Color(
            GetComponent<Renderer>().material.color.r,
            GetComponent<Renderer>().material.color.g,
            GetComponent<Renderer>().material.color.b,
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