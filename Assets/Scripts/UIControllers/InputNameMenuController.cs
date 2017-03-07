using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputNameMenuController : MonoBehaviour
{

    private bool placeholderRemains;
    public GameObject arrowUp;
    public Transform arrowSpawn;

    private WWWFormScoreUpload wwwFormScoreUpload;

    void Start()
    {
        InitFormScoreUpload();
        placeholderRemains = true;
    }

    void InitFormScoreUpload()
    {
        GameObject WWWControllerGameObject = GameObject.FindGameObjectWithTag("WWWController");

        if (WWWControllerGameObject != null)
            wwwFormScoreUpload = WWWControllerGameObject.GetComponent<WWWFormScoreUpload>();
        else
            Debug.Log("Error: WWWController no encontrado.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Return))
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject, null);
            if (placeholderRemains)
            {
                Destroy(GetComponentInChildren<GUITexture>().gameObject);
                placeholderRemains = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) && !placeholderRemains && GetComponent<InputField>().text != "")
        {
            PlayerPrefs.SetString("name", GetComponent<InputField>().text);
            Instantiate(arrowUp, arrowSpawn.position + new Vector3(0, 1, -2), arrowSpawn.rotation);
            wwwFormScoreUpload.UploadHighscore();
            this.gameObject.SetActive(false);
        }
    }
}
