using UnityEngine;
using System.Collections;

public class ArrowUp : MonoBehaviour {
    public float upForce = 1.0f;
	void Update () {
        GetComponent<Rigidbody>().AddForce( new Vector3(0f,upForce,0f));
	}
}
