using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

    public SingleTouch SingleTouch;
    [HideInInspector]
    public bool DisableControls;

	// Use this for initialization
	void Start () {
	    SingleTouch = new SingleTouch();
	}
	
	// Update is called once per frame
	void Update () 
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {           
            Application.Quit(); 
       }

        if (DisableControls) { return; }

        SingleTouch.Update();
	}
}
