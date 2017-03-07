using UnityEngine;
using System.Collections;

public class BarrierOnClick : MonoBehaviour {

    private bool click;

    void OnMouseDown()
    {
        click = true;
    }

    void OnMouseUp()
    {
        click = false;
    }

    public bool getClick()
    {
        return click;
    }
}
