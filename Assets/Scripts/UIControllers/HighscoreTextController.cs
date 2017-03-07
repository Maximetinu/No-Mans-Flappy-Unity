using UnityEngine;
using System.Collections;

public class HighscoreTextController : MonoBehaviour {

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("Error: Game Controller no encontrado.");

        GetComponent<GUIText>().text = "Best: " + gameController.highscore;
    }
}
