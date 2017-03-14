using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundBMode : MonoBehaviour {

    public Material bMaterial;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("active_mode", 1) == 2)
            this.GetComponent<Renderer>().material = bMaterial;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
