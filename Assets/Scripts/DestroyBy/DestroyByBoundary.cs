using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

    private GameController gameController;

    void Start()
    {
        InitGameController();
    }

    void InitGameController()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("Error: Game Controller no encontrado.");
    }

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        if (other.tag == "Player" && !gameController.getGameOver())
        {
            gameController.setGameOver();
        }
    }

}
