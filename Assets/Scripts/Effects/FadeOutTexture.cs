using UnityEngine;
using System.Collections;

public class FadeOutTexture : MonoBehaviour
{

    public float timeInFadeOut;
    private float waitFadeTransition = 0.001f;
    private float fadingSpeed;

    private float alpha;

    public bool killAfter = false;

    // Use this for initialization
    void Start()
    {
        alpha = GetComponent<GUITexture>().color.a;
        fadingSpeed = alpha / (timeInFadeOut / waitFadeTransition);
        StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
        if (killAfter && alpha <= 0)
            Destroy(gameObject);
    }

    IEnumerator Fade()
    {
        while (alpha >= 0)
        {
            alpha -= fadingSpeed;
            updateAlpha();
            yield return new WaitForSeconds(waitFadeTransition);
        }
    }

    void updateAlpha()
    {
        GetComponent<GUITexture>().color = new Color(
                GetComponent<GUITexture>().color.r,
                GetComponent<GUITexture>().color.g,
                GetComponent<GUITexture>().color.b,
                this.alpha);
    }
}
