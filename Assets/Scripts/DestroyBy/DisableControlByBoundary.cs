using UnityEngine;
using System.Collections;

public class DisableControlByBoundary : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<PlayerController>().outOfBoundary = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<PlayerController>().outOfBoundary = false;
    }
}
