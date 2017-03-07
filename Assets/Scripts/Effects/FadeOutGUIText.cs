using UnityEngine;
using System.Collections;

public class FadeOutGUIText : MonoBehaviour
{

    public float timeInFadeOut;
    private float waitFadeTransition = 0.001f;
    private float fadingSpeed;

    private float alpha;

    public bool killAfter = false;

    // Use this for initialization
    void Start()
    {
        alpha = GetComponent<GUIText>().color.a;
        fadingSpeed = alpha / (timeInFadeOut / waitFadeTransition);
    }

    public void StartFading()
    {
        alpha = GetComponent<GUIText>().color.a;
        StartCoroutine(Fade());
    }

    public void Restart()
    {
        this.Start();
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
        GetComponent<GUIText>().color = new Color(
                GetComponent<GUIText>().color.r,
                GetComponent<GUIText>().color.g,
                GetComponent<GUIText>().color.b,
                this.alpha);
    }
}
