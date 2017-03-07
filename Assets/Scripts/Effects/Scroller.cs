using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour {

    public float speed = 1.0f;
    private float s;

    //[HideInInspector]
    //private bool isPause;

	// Use this for initialization
	void Start () {
        //isPause = false;
        Vector2 startOffset = new Vector2(Random.Range(-10f, 10f), Random.Range(-5.0f, -7.0f));
        s = speed / 1000;
        this.GetComponent<Renderer>().material.SetTextureOffset("_MainTex",startOffset);
    }

    public void stop()
    {
        s = 0;
    }

    public void startAgain()
    {
        s = speed / 1000;
    }

    public void setPause(bool isP)
    {
        //isPause = isP;
        if (isP)
            this.stop();
        else
            this.startAgain();
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", this.GetComponent<Renderer>().material.GetTextureOffset("_MainTex") + new Vector2(-s,0.0f));
	}
}
