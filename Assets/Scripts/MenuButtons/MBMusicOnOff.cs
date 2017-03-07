using UnityEngine;

public class MBMusicOnOff : MonoBehaviour,MBAction {

    private Texture musicOn;
    public Texture musicOff;

    private bool active;

    private SoundController soundController;

	// Use this for initialization
	void Start () {
        active = true;
        musicOn = GetComponent<Renderer>().material.GetTexture("_MainTex");
        this.InitSoundController();

        if (PlayerPrefs.GetString("music", "True") == false.ToString())
        {
            active = false;
            GetComponent<Renderer>().material.SetTexture("_MainTex", musicOff);
        }

    }

    private void InitSoundController()
    {
        GameObject soundControllerObject = GameObject.FindGameObjectWithTag("SoundController");

        if (soundControllerObject != null)
            soundController = soundControllerObject.GetComponent<SoundController>();
        else
            Debug.Log("Error: Sound Controller no encontrado.");
    }

    void MBAction.doAction()
    {
        active = !active;
        if (active)
        {
            GetComponent<Renderer>().material.SetTexture("_MainTex", musicOn);
            soundController.backgroundMusic.Play();
        }
        else
        {
            GetComponent<Renderer>().material.SetTexture("_MainTex", musicOff);
            soundController.backgroundMusic.Stop();
        }
        PlayerPrefs.SetString("music", active.ToString());
    }
}
