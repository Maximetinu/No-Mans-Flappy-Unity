using UnityEngine;

public class MBUploadHighscore : MonoBehaviour,MBAction {

    public GameObject arrowUp;

    public GameObject input;

    private WWWFormScoreUpload wwwFormScoreUpload;

	// Use this for initialization
	void Start () {
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

    void MBAction.doAction()
    {
        //transform.GetComponentInParent<ButtonsSelectionController>().buttons.RemoveAt(0);
        if (PlayerPrefs.GetString("name", "") != "")
        {
            Instantiate(arrowUp, gameObject.transform.position - new Vector3(0, -1, 1), Quaternion.identity);
            wwwFormScoreUpload.UploadHighscore();
        }
        else
            input.SetActive(true);
        //Destroy(gameObject);
    }
}
