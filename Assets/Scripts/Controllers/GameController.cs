using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public GameObject obstacle;
    public Transform spawnPosition;
    public float variation;
    private Vector3 spawnPositionV;

    public float startWait = 0;
    public float obstacleWait = 1.7f;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int highscore;

    private bool gameOver;
    //private bool gameStarted;

    public GameObject background;
    public Material blackBackgroundMaterial;

    public GUIText scoreText;

    public GameObject clickBarrier;
    public GameObject menuButton;

    public GUITexture initText;
    public GUITexture restartButton;
    public float waitForRestartButton = 1.0f;

    public static List<GameObject> obstacles;

    public SoundController soundController;

    public BModeErrorTextController bModeErrorTextController;

    void Start()
    {
        gameOver = false;
        //gameStarted = false;
        score = 0;
        InitHighscore();
        //this.updateScoreText();
        scoreText.text = "";
        spawnPositionV = spawnPosition.position;
        obstacles = new List<GameObject>();
    }

    /// ///////////////////////////////////////////////////////////

    public void InitHighscore()
    {
        if (PlayerPrefs.GetInt("active_mode", 1) == 2)
            highscore = PlayerPrefs.GetInt("highscore_b", 0);
        else
            highscore = PlayerPrefs.GetInt("highscore", 0);
    }

    private void UpdateHighscore()
    {
        if (PlayerPrefs.GetInt("active_mode", 1) == 2)
            PlayerPrefs.SetInt("highscore_b", score);
        else
            PlayerPrefs.SetInt("highscore", score);
    }

    /// ///////////////////////////////////////////////////////////
    /// 
    public GameObject title;

    public void startSpawn()
    {
        //gameStarted = true;
        //menuButton.SetActive(false);
        menuButton.GetComponent<MenuButtonController>().FadeOut();
        title.GetComponentsInChildren<FadeOutMaterial>()[0].enabled = title.GetComponentsInChildren<FadeOutMaterial>()[1].enabled = true;
        clickBarrier.SetActive(false);
        Destroy(initText.gameObject);
        StartCoroutine(SpawnObstacles());
    }

    public void upScore()
    {
        score += 1;
        this.updateScoreText();
        soundController.scoreEffect.Play();
    }

    private static void setObstaclesGameOver(GameObject obstac)
    {
        if (obstac != null)
        {
            obstac.GetComponent<Rigidbody>().velocity = Vector3.zero;
            foreach (Renderer i in obstac.GetComponentsInChildren<Renderer>())
            {
                i.material.SetColor("_Color", Color.black);
            }
        }
    }

    private void updateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void setGameOver()
    {
        gameOver = true;
        if (score > highscore)
        {
            highscore = score;
            UpdateHighscore();
        }
        obstacles.ForEach(setObstaclesGameOver);
        setBackgroundGameOver();
        if (score != 0)
            scoreText.GetComponent<ScoreTextController>().isGameOver();
        else
            StartCoroutine(ShowRestartButton());
        soundController.backgroundMusic.Stop();
        soundController.deathEffect.Play();
    }

    public bool getGameOver()
    {
        return gameOver;
    }

    private void setBackgroundGameOver()
    {
        background.GetComponent<Scroller>().stop();
        Vector2 offset = background.GetComponent<Renderer>().material.GetTextureOffset("_MainTex");
        background.GetComponent<Renderer>().material = blackBackgroundMaterial;
        background.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }

    // SetGameOver()
    // Update() --> si flag de restart == true, dar la posibilidad de pulsar 'R' para reiniciar.

    IEnumerator SpawnObstacles()
    {
        // ESPERA INICIAL
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            
            //spawnPositionV.y = spawnPositionV.y + Random.Range(-variation, variation);

            // ESPERA ENTRE OBSTACULOS
            yield return new WaitForSeconds(obstacleWait);

            if (gameOver)
                break;

            float oscilation = Random.Range(-variation, variation);
           

            GameObject tempObstacle = Instantiate(obstacle, spawnPositionV + new Vector3(0, oscilation, 0), Quaternion.identity) as GameObject;
            obstacles.Add(tempObstacle);

            //if (gameOver)
            //{
            //    restart = true;
            //    restartText.text = "Press 'R' to restart";
            //    break;
            //}
        }
    }

    IEnumerator ShowRestartButton()
    {
        yield return new WaitForSeconds(waitForRestartButton);
        restartButton.gameObject.SetActive(true);
    }
}
