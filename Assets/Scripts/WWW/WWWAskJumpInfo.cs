using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWAskJumpInfo : MonoBehaviour {

    [HideInInspector]
    public float jump;
    [HideInInspector]
    public float jumpRate;
    [HideInInspector]
    public bool error;

    // Use this for initialization
    IEnumerator Start () {
        
        error = false;
        jump = 13.3f;
        jumpRate = 0.3f;

        // Create a download object
        WWW answer = new WWW(WWWConfig.jumpInfoURL);

        // Wait until the download is done
        yield return answer;

        if (!string.IsNullOrEmpty(answer.error))
        {
            error = true;
            //Debug.Log("Error downloading: " + answer.error);
        }
        else
        {
            char[] delimiterChars = {','};
            string[] values = (answer.text).Split(delimiterChars);
            jump = float.Parse(values[0]);
            jumpRate = float.Parse(values[1]);
        }

        if (!error)
        {
            InitPlayer();
            playerController.jump = jump;
            playerController.jumpRate = jumpRate;
        }

        Debug.Log("jumpWWW = " + jump);
        Debug.Log("jumpRate= " + jumpRate);
    }



    PlayerController playerController;

    void InitPlayer()
    {
        GameObject PlayerGameObject = GameObject.FindGameObjectWithTag("Player");

        if (PlayerGameObject != null)
            playerController = PlayerGameObject.GetComponent<PlayerController>();
        else
            Debug.Log("Error: Player no encontrado.");
    }



}
