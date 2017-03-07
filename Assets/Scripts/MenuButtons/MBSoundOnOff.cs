using UnityEngine;

public class MBSoundOnOff : MonoBehaviour,MBAction {

    private Texture soundOn;
    public Texture soundOff;

    private bool active;

    private SoundController soundController;

    // Use this for initialization
    void Start () {
        active = true;
        soundOn = GetComponent<Renderer>().material.GetTexture("_MainTex");
        this.InitSoundController();

        if (PlayerPrefs.GetString("sound", "True") == false.ToString())
        {
            active = false;
            GetComponent<Renderer>().material.SetTexture("_MainTex", soundOff);
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
            GetComponent<Renderer>().material.SetTexture("_MainTex", soundOn);
            soundController.jumpEffect.mute = false;
            soundController.scoreEffect.mute = false;
            soundController.deathEffect.mute = false;
        }
        else
        {
            GetComponent<Renderer>().material.SetTexture("_MainTex", soundOff);
            soundController.jumpEffect.mute = true;
            soundController.scoreEffect.mute = true;
            soundController.deathEffect.mute = true;
        }
        PlayerPrefs.SetString("sound", active.ToString());
    }
}
