using UnityEngine;
using System.Collections;

public class BModeErrorTextController : MonoBehaviour {

    public float timeError;

	// Use this for initialization
	void Start () {
        this.GetComponent<GUIText>().text = "";
	}

    public void ErrorConexion()
    {
        fillAlpha();
        this.GetComponent<GUIText>().text = "Conection error - 404";
        StartCoroutine(Desvanecer());
    }

    public void ErrorComunidad()
    {
        fillAlpha();
        this.GetComponent<GUIText>().text = "Nobody is ready to play this yet";
        StartCoroutine(Desvanecer());
    }

    public void ErrorIndividual( int individualLimit)
    {
        fillAlpha();
        this.GetComponent<GUIText>().text = "Highscore higher than " + individualLimit + " needed";
        StartCoroutine(Desvanecer());
    }

    IEnumerator Desvanecer()
    {
        yield return new WaitForSeconds(timeError);
        GetComponent<FadeOutGUIText>().StartFading();
    }

    private void fillAlpha()
    {
        GetComponent<GUIText>().color = new Color(
                GetComponent<GUIText>().color.r,
                GetComponent<GUIText>().color.g,
                GetComponent<GUIText>().color.b,
                1.0f);
    }
}
