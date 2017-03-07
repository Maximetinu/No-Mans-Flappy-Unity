using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControllerBMode : MonoBehaviour {

    public float turboAmount = 10.0f;
    public float turboDuration = 0.25f;
    public float brakeAmount = 0.1f;

    public SoundController soundController;
    private AudioSource turboEffect;

    // Use this for initialization
    void Start () {
        //if (!SceneManager.GetActiveScene().name.Equals("scene02"))
        if (PlayerPrefs.GetInt("active_mode", 1) == 1)
            this.enabled = false;
        turboEffect = soundController.turboEffect;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightAlt) || Input.GetMouseButtonDown(1))
        {
            turboEffect.Play();
            StartCoroutine(ApplyTurbo());
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftAlt) || Input.GetMouseButton(2))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(-brakeAmount, 0, 0);
        }
        //Debug.Log ("mode_active = " + PlayerPrefs.GetInt("mode_active",1));
        bool turbo_touch = false;
        foreach (Touch touch in Input.touches)
        {
            turbo_touch = touch.tapCount > 1;
        }
        if (turbo_touch)
        {
            turboEffect.Play();
            StartCoroutine(ApplyTurbo());
        }
    }

    IEnumerator ApplyTurbo()
    {
        this.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionY;
        GetComponent<PlayerController>().GuardarVelocidad();
        GetComponent<Rigidbody>().velocity += new Vector3(turboAmount, 0, 0);
        yield return new WaitForSeconds(turboDuration);
        this.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
        GetComponent<PlayerController>().RestaurarVelocidad();
        GetComponent<Rigidbody>().velocity += new Vector3(turboAmount / 3, 0, 0);
    }
}
