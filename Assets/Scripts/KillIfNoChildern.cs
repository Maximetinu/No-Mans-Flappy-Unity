using UnityEngine;
using System.Collections;

public class KillIfNoChildern : MonoBehaviour {
	void Update () {
        if (transform.childCount == 0)
            Destroy(gameObject);
	}
}
