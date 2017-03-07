using UnityEngine;
using System.Collections;

public class WWWDeleteHighscore : MonoBehaviour {

    public void DeleteHighscore() { if (PlayerPrefs.GetString("name", "") != "") StartCoroutine(Delete()); }

    IEnumerator Delete()
    {
        string name = PlayerPrefs.GetString("name");
        int score = PlayerPrefs.GetInt("highscore", 0);
        //int score_B = PlayerPrefs.GetInt("highscore_b", 0);

        WWWForm form = new WWWForm();
        form.AddField("playerName", name);
        form.AddField("score", score);
        form.AddField("game", WWWConfig.gameName);
        string stringHashed = CryptoUtilities.MD5Sum(WWWConfig.gameName + name + score.ToString() + WWWConfig.hashKey);
        form.AddField("hash", stringHashed);
        WWW answer = new WWW(WWWConfig.setHighscoresInactivesURL, form);

        // Wait until the download is done
        yield return answer;

        if (!string.IsNullOrEmpty(answer.error))
        {
            Debug.Log("Error downloading: " + answer.error);
            if (PlayerPrefs.GetString("error_on_delete_name", "") == "")
            {
                PlayerPrefs.SetString("error_on_delete_name", PlayerPrefs.GetString("name", ""));
                PlayerPrefs.SetInt("error_on_delete_score_A", PlayerPrefs.GetInt("highscore"));
                PlayerPrefs.SetInt("error_on_delete_score_B", PlayerPrefs.GetInt("highscore_b"));
            }
        }
        else
        {
            Debug.Log(answer.text);
        }
        PlayerPrefs.DeleteKey("name");
        PlayerPrefs.DeleteKey("highscore");
        PlayerPrefs.DeleteKey("highscore_b");
    }

}
