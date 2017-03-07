using UnityEngine;
using System.Collections;

public class WWWFormScoreUpload : MonoBehaviour
{
    string highscore_url = WWWConfig.highscoreURL;
    string playName;
    string scoreToAskFor = "highscore";
    int score;

    public void UploadHighscore()
    {
        StartCoroutine(Upload());
    }

    // Use this for initialization
    IEnumerator Upload()
    {
        if (PlayerPrefs.GetInt("active_mode", 1) == 2)
        {
            highscore_url = WWWConfig.highscoreURL_B;
            scoreToAskFor = "highscore_b";
        }

        playName = PlayerPrefs.GetString("name", "");
        score = PlayerPrefs.GetInt(scoreToAskFor, 0);
  
        if ((playName != "") && (score != 0))
        {
            // Create a form object for sending high score data to the server
            WWWForm form = new WWWForm();
            // Assuming the perl script manages high scores for different games
            form.AddField("game", WWWConfig.gameName);
            // The name of the player submitting the scores
            form.AddField("playerName", playName);
            // The score
            form.AddField("score", score);
            // The hash
            string stringHashed = CryptoUtilities.MD5Sum(WWWConfig.gameName + playName + score.ToString() + WWWConfig.hashKey);
            form.AddField("hash", stringHashed);

            // Create a download object
            WWW download = new WWW(highscore_url, form);

            // Wait until the download is done
            yield return download;

            if (!string.IsNullOrEmpty(download.error))
            {
                Debug.Log("Error downloading: " + download.error);
            }
            else
            {
                Debug.Log(download.text);
            }
        }
        else
            Debug.Log("PlayerName vacío o Highscore = 0");
    }
}