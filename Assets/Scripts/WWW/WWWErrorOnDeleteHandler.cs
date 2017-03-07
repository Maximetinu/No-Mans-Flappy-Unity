using UnityEngine;
using System.Collections;

public class WWWErrorOnDeleteHandler : MonoBehaviour {
	void Start () {
        if (PlayerPrefs.GetString("error_on_delete_name", "") != "")
            StartCoroutine(DeletePreviousError());
        else
            this.enabled = false;

        if (PlayerPrefs.GetString("error_on_delete_name", "") != "")
            Debug.Log("TRATAMIENTO DE ERROR AL BORRAR COMENZADO");
    }
    IEnumerator DeletePreviousError()
    {
        string name = PlayerPrefs.GetString("error_on_delete_name");
        int score = PlayerPrefs.GetInt("error_on_delete_score_A", 0);
        //int score_B = PlayerPrefs.GetInt("error_on_delete_score_B", 0);

        WWWForm form = new WWWForm();
        form.AddField("playerName", name);
        form.AddField("score_A", score);
        form.AddField("game", WWWConfig.gameName);
        string stringHashed = CryptoUtilities.MD5Sum(WWWConfig.gameName + name + score.ToString() + WWWConfig.hashKey);
        form.AddField("hash", stringHashed);
        WWW answer = new WWW(WWWConfig.setHighscoresInactivesURL, form);
        

        // Wait until the download is done
        yield return answer;

        if (!string.IsNullOrEmpty(answer.error))
        {
            Debug.Log("Error downloading: " + answer.error);;
        }
        else
        {
            Debug.Log(answer.text);
            PlayerPrefs.DeleteKey("error_on_delete_score_A");
            PlayerPrefs.DeleteKey("error_on_delete_score_B");
            PlayerPrefs.DeleteKey("error_on_delete_name");
        }
    }

}
