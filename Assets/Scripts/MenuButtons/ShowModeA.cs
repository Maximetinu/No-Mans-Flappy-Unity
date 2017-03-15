using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowModeA : MonoBehaviour {
    public Texture AModeTexture;
    public Texture BModeTexture;

    private PlayerControllerBMode playerControllerBMode;
    private GameController gameController;

    void Start () {
        InitPlayerController();
        InitGameController();
        UpdateModeAndTexture();        
    }

    void InitPlayerController()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");

        if (playerGameObject != null)
            playerControllerBMode = playerGameObject.GetComponent<PlayerControllerBMode>();
        else
            Debug.Log("Error: Player no encontrado.");
    }

    private void InitGameController()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("Error: Game Controller no encontrado.");
    }

    public void UpdateModeAndTexture(){
        if (PlayerPrefs.GetInt("active_mode", 1) == 2)
        {
            GetComponent<Renderer>().material.SetTexture("_MainTex", AModeTexture);
            playerControllerBMode.enabled = true;
            gameController.InitHighscore();
            gameController.ChangeBackground(2);
        }
        else
        {
            GetComponent<Renderer>().material.SetTexture("_MainTex", BModeTexture);
            playerControllerBMode.enabled = false;
            gameController.InitHighscore();
            gameController.ChangeBackground(1);
        }
    }
}
