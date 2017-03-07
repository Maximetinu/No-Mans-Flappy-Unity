using UnityEngine;
using System.Collections;

public class ClickReceiver : MonoBehaviour {
	void OnMouseDown()
    {
        GetComponent<MBAction>().doAction();
    }
}
