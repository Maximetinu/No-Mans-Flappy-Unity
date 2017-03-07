using UnityEngine;
using System.Collections;

public class DisableDebug : MonoBehaviour {
	void Start () {
        #if UNITY_EDITOR
            Debug.logger.logEnabled = true;
        #else
            Debug.logger.logEnabled = false; 
        #endif
    }
}
