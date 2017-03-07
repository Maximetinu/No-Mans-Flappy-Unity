using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour {

    public GameObject highscoreTextGameObject;
    public GameObject uploadHighscoreGameObject;
    public GameObject inputName;

    public GameObject arrowUp;
    public Transform arrowSpawn;

    [HideInInspector]
    public bool attendRestartKeys;

    public GameController gameController;
    private WWWFormScoreUpload wwwFormScoreUpload;

    void Start()
    {
        highscoreTextGameObject.SetActive(true);
        //if (gameController.score >= PlayerPrefs.GetInt("highscore", 0))
        uploadHighscoreGameObject.SetActive(true);
        attendRestartKeys = true;

        InitFormScoreUpload();
    }

    void InitFormScoreUpload()
    {
        GameObject WWWControllerGameObject = GameObject.FindGameObjectWithTag("WWWController");

        if (WWWControllerGameObject != null)
            wwwFormScoreUpload = WWWControllerGameObject.GetComponent<WWWFormScoreUpload>();
        else
            Debug.Log("Error: WWWController no encontrado.");
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (attendRestartKeys)
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } else if (Input.GetKeyDown(KeyCode.U))
            {
                Destroy(uploadHighscoreGameObject);
                if (PlayerPrefs.GetString("name", "") == "")
                {
                    inputName.SetActive(true);
                    attendRestartKeys = false;
                }
                else
                {
                    Instantiate(arrowUp, arrowSpawn.position, arrowSpawn.rotation);
                    wwwFormScoreUpload.UploadHighscore();
                }                
            }
        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                fingerCount++;
        }

        if (fingerCount > 0)
            this.OnMouseDown();
    }
}
