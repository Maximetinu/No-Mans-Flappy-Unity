using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {
    
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
        if (other.tag == "Player" && !other.GetComponentInParent<PlayerController>().isDead)
        {
            gameController.upScore();
            Destroy(this.gameObject);
        }
    }
}
