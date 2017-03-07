using UnityEngine;

public class MBDeleteData : MonoBehaviour,MBAction {

    public GameObject tick;

    private GameController gameController;
    private WWWDeleteHighscore wwwDeleteHighscore;

    void Start()
    {
        InitGameController();
        InitDeleteHighscore();
    }

    void InitGameController()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("Error: Game Controller no encontrado.");
    }

    void InitDeleteHighscore()
    {
        GameObject WWWControllerGameObject = GameObject.FindGameObjectWithTag("WWWController");

        if (WWWControllerGameObject != null)
            wwwDeleteHighscore = WWWControllerGameObject.GetComponent<WWWDeleteHighscore>();
        else
            Debug.Log("Error: WWWController no encontrado.");
    }

    void MBAction.doAction()
    {
        //transform.GetComponentInParent<ButtonsSelectionController>().buttons.RemoveAt(1);
        Instantiate(tick, gameObject.transform.position - new Vector3(0,0,1), Quaternion.identity);
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.DeleteKey("name");
        wwwDeleteHighscore.DeleteHighscore();
        //PlayerPrefs.DeleteKey("highscore");
        //PlayerPrefs.DeleteKey("highscore_b");

        gameController.highscore = 0;
        //Destroy(gameObject);
    }
}
