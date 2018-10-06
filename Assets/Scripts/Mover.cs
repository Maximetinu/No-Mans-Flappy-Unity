using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed = 100.0f;

    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(-speed, 0, 0));
    }

}
