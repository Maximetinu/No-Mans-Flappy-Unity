using UnityEngine;
using System.Collections;

public class SetObstacleBMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//if (PlayerPrefs.GetInt("mode_active",1) == 1)
        //    this.enabled = false;
        if (PlayerPrefs.GetInt("active_mode", 1) == 2){
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
            // Al box collider de los dos primeros hijos isTrigger = false
            GetComponentsInChildren<BoxCollider>()[1].isTrigger = false;
            GetComponentsInChildren<BoxCollider>()[2].isTrigger = false;
        }
	}
}
