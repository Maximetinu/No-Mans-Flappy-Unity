using UnityEngine;
using System.Collections;
using System;

public class WWWAskForBMode : MonoBehaviour
{
    [HideInInspector]
    public bool unlockByCommunity;
    [HideInInspector]
    public int individualLimit;
    [HideInInspector]
    public bool error;

    // Use this for initialization
    IEnumerator Start()
    {
        unlockByCommunity = false;
        error = false;
        individualLimit = 0;
        // Create a download object
        WWW answer = new WWW(WWWConfig.unblockByCommunityURL);

        // Wait until the download is done
        yield return answer;

        if (!string.IsNullOrEmpty(answer.error))
        {
            error = true;
            //Debug.Log("Error downloading: " + answer.error);
        }
        else
        {
            //unlockByCommunity = Convert.ToBoolean(answer.text);
            if (answer.text == "1")
                unlockByCommunity = true;
            else
                unlockByCommunity = false;
        }

        if (unlockByCommunity)
        {
            answer = new WWW(WWWConfig.individualLimitURL);
            yield return answer;

            if (!string.IsNullOrEmpty(answer.error))
            {
                error = true;
                //Debug.Log("Error downloading: " + answer.error);
            }
            else
            {
                individualLimit = Convert.ToInt16(answer.text);
            }
        }

        Debug.Log("error = " + error);
        Debug.Log("unblockByCommunity= " + unlockByCommunity);
        Debug.Log("individualLimit= " + individualLimit);
    }
}