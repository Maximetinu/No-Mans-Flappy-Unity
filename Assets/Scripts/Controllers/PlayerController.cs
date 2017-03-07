using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float jump = 20.0f;
    public float jumpRate = 0.5F;
    private float nextJump = 0.0F;

    public BarrierOnClick clickBarrier;

    //private float deathTime = 6.0F;
    public float deathScaleSpeed = 1.0F;

    public float startOscillation = 1.0F;

    [HideInInspector]  
    public bool outOfBoundary;
    [HideInInspector]
    public bool isDead;
    [HideInInspector]
    public bool inStart;

    private bool isPause;

    private GameController gameController;

    public SoundController soundController;
    private AudioSource jumpEffect;

    public GameObject invisibleWallBMode;

    void Start()
    {
        isPause = false;
        isDead = false;
        outOfBoundary = false;
        inStart = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().AddForce(new Vector3(0, startOscillation));
        InitGameController();
        jumpEffect = soundController.jumpEffect;
    }

    private void InitGameController()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("Error: Game Controller no encontrado.");
    }

    public void setPause(bool isP)
    {
        isPause = isP;
        if (isP)
        {
            GuardarVelocidad();
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            RestaurarVelocidad();
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private Vector3 velocidad;

    public void GuardarVelocidad()
    {
        velocidad = GetComponent<Rigidbody>().velocity;
    }

    public void RestaurarVelocidad()
    {
        GetComponent<Rigidbody>().velocity = velocidad;
    }

    public void setDead()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<SphereCollider>().isTrigger = false;
        this.isDead = true;
    }


    void FixedUpdate()
    {
        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                fingerCount++;
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || fingerCount > 0 ||
            (clickBarrier.getClick())
            ) && Time.time > nextJump && !isDead && !outOfBoundary && !isPause)
        {
            if (inStart) {
                inStart = false;
                this.GetComponent<Rigidbody>().useGravity = true;
                gameController.startSpawn();
            }
            nextJump = Time.time + jumpRate;
            GetComponent<Rigidbody>().velocity = new Vector3(0, jump, 0);
            jumpEffect.Play();
        }

        //if (!GetComponent<Rigidbody>().useGravity && Time.time > deathTime)
        //    GetComponent<Rigidbody>().useGravity = true;

        if (inStart)
        {
            if (this.transform.localPosition.y > 0.0f)
                GetComponent<Rigidbody>().AddForce(new Vector3(0, -startOscillation, 0));
            else
                GetComponent<Rigidbody>().AddForce(new Vector3(0, +startOscillation, 0));
        }
    }

    void Update()
    {
        /*
        if (inStart)
        {
            if (this.transform.localPosition.y < startOscillationRange && oscillationUp)
                this.transform.localPosition += new Vector3(0, startOscillationSpeed, 0);
            else if (this.transform.localPosition.y >= startOscillationRange)
                oscillationUp = false;

            if (this.transform.localPosition.y > -startOscillationRange && !oscillationUp)
                this.transform.localPosition -= new Vector3(0, startOscillationSpeed, 0);
            else if (this.transform.localPosition.y <= -startOscillationRange)
                oscillationUp = true;
        }
        */



        if (isDead)
        {
            Destroy(invisibleWallBMode);
            if (this.transform.localScale.x < 50.0f)
                this.transform.localScale += new Vector3(deathScaleSpeed, deathScaleSpeed, deathScaleSpeed);
            else
                Destroy(this.gameObject);
        }
    }
}

