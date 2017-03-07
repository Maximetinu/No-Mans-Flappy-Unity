using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("Error: Game Controller no encontrado.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().setDead();
            if (!gameController.getGameOver())
                gameController.setGameOver();
        }
    }
}
