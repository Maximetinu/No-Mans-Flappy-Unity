using UnityEngine;
using System.Collections;

public class ScoreTextController : MonoBehaviour {

    private GUIText scoreText;
    public float enlargeScoreTextWait = 1.0f;
    public float finalPosition = 0.6f;
    public GUITexture restartButton;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<GUIText>();
	}

    public void isGameOver()
    {
        StartCoroutine(EnlargeScoreText());
    }

    IEnumerator EnlargeScoreText()
    {
        yield return new WaitForSeconds(enlargeScoreTextWait);
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            scoreText.transform.position -= new Vector3(0, 0.01f, 0);

            if (scoreText.transform.position.y <= finalPosition)
                break;
        }
        yield return new WaitForSeconds(enlargeScoreTextWait / 3);
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            scoreText.fontSize++;

            if (scoreText.fontSize == 70)
                break;
        }
        restartButton.gameObject.SetActive(true);
    }
}
