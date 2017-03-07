using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonsSelectionController : MonoBehaviour {

    [HideInInspector]
    public List<Material> buttons;
    private int selected;

    private bool start = true;

	// Use this for initialization
	void Start () {
        buttons = new List<Material>();
        for (int i = 0; i < transform.childCount; i++)
            buttons.Add(transform.GetChild(i).GetComponent<Renderer>().material);
    }

    // Update is called once per frame
    void Update () {
        if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && start)
        {
            start = false;
            selected = -1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
            selected++;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            if (selected == 0)
                selected -= buttons.Count - 1;
            else
                selected--;

        selected = System.Math.Abs(selected % buttons.Count);

        this.turnOffBlinks();

        if(!start)
            buttons[selected].SetFloat("_Blink", 1.0f);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            transform.GetChild(selected).GetComponent<MBAction>().doAction();
            //if ((transform.GetChild(selected).name == "UploadHighscoreButton") || (transform.GetChild(selected).name == "DeleteData"))
               //buttons.RemoveAt(selected);
        }
    }

    private void turnOffBlinks()
    {
        for (int i = 0; i < buttons.Count; i++)
            buttons[i].SetFloat("_Blink", 0.0f);
    }
}
