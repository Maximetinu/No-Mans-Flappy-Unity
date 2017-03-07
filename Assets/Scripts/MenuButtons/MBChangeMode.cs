using UnityEngine;
using UnityEngine.SceneManagement;

public class MBChangeMode : MonoBehaviour,MBAction {

    private WWWAskForBMode wwwAskForBMode;
    private GameController gameController;

    private bool error;
    private bool unlockByCommunity;
    private int individualLimit;

    void Start()
    {
        InitAskForBMode();
        InitGameController();
        error = wwwAskForBMode.error;
        unlockByCommunity = wwwAskForBMode.unlockByCommunity;
        individualLimit = wwwAskForBMode.individualLimit;
    }

    void InitAskForBMode()
    {
        GameObject WWWControllerGameObject = GameObject.FindGameObjectWithTag("WWWController");

        if (WWWControllerGameObject != null)
            wwwAskForBMode = WWWControllerGameObject.GetComponent<WWWAskForBMode>();
        else
            Debug.Log("Error: WWWController no encontrado.");
    }

    private void InitGameController()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("Error: Game Controller no encontrado.");
    }

    void MBAction.doAction()
    {
        if (PlayerPrefs.GetInt("active_mode", 1) == 2)
            PlayerPrefs.SetInt("active_mode", 1);
        else if (this.error)
            gameController.bModeErrorTextController.ErrorConexion();    //Debug.Log("ERROR AL CONECTAR");
        else if (!unlockByCommunity)
            gameController.bModeErrorTextController.ErrorComunidad();   //Debug.Log("NO DESBLOQUEADO POR LA COMUNIDAD");
        else if (PlayerPrefs.GetInt("highscore", 0) < individualLimit)
            gameController.bModeErrorTextController.ErrorIndividual(individualLimit);    //Debug.Log("NO HAS SUPERADO EL LIMITE DE PUNTUACION INDIVIDUAL");
        else
            PlayerPrefs.SetInt("active_mode", 2);
        GetComponent<ShowModeA>().UpdateModeAndTexture();
    }
}
