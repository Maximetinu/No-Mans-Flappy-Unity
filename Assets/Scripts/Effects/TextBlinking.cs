using UnityEngine;
using System.Collections;

public class TextBlinking : MonoBehaviour {

    public float speed = 2.0f;

    public bool active = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        GetComponent<GUITexture>().color = new Color(
            GetComponent<GUITexture>().color.r,
            GetComponent<GUITexture>().color.g,
            GetComponent<GUITexture>().color.b,
            Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
