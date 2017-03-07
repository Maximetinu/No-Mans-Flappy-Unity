using UnityEngine;
using System.Collections;

public class MenuButtonController : MonoBehaviour {

    public GameObject displayText;
    public PlayerController playerController;
    public Scroller backgroundScroller;

    public GameObject pauseMenu;
    private GameObject instantiatedPauseMenu;
    //public Transform pauseMenuSpawnPosition;

    private bool aceptInput = true;

    private bool isPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && aceptInput)
        {
            UpdatePause();
        }
    }

    void OnMouseDown()
    {
        if (aceptInput)
            UpdatePause();
    }

    private void UpdatePause()
    {
        if (!isPause)
        {
            instantiatedPauseMenu = Instantiate(pauseMenu,Vector3.zero,Quaternion.identity) as GameObject;
        }
        else
        {
            Destroy(instantiatedPauseMenu); // CHECKAR SI ES NULL?? NO HACE FLATA NO?
        }
        isPause = !isPause;
        playerController.setPause(isPause);
        backgroundScroller.setPause(isPause);
        displayText.SetActive(!isPause);
    }

    public void FadeOut()
    {
        aceptInput = false;
        this.GetComponent<FadeOutTexture>().enabled = true;
        this.GetComponent<ArrowUp>().enabled = true;
    }
}
