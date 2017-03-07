using UnityEngine;
using System.Collections;

public class FadeOutMaterial : MonoBehaviour {

    public float timeInFadeOut;
    private float waitFadeTransition = 0.001f;
    private float fadingSpeed;

    private float alpha;

    public bool killAfter = false;

	// Use this for initialization
	void Start () {
        alpha = GetComponent<Renderer>().material.color.a;
        fadingSpeed = alpha / (timeInFadeOut / waitFadeTransition);
        StartCoroutine(Fade());
    }
	
	// Update is called once per frame
	void Update () {
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
        GetComponent<Renderer>().material.color = new Color(
                GetComponent<Renderer>().material.color.r,
                GetComponent<Renderer>().material.color.g,
                GetComponent<Renderer>().material.color.b,
                this.alpha);
    }
}
