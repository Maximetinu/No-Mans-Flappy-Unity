using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed = 100.0f;

    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(-speed,0,0));
    }

    // Update is called once per frame
    /*void Update () {
        this.GetComponent<Transform>().position = new Vector3(this.GetComponent<Transform>().position.x - s, this.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z);
	}*/
}
