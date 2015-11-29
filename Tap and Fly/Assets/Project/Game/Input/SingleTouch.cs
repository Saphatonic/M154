using UnityEngine;
using System.Collections;

public class SingleTouch {

    public bool Began;
    public bool Moved;
    public bool Stationary;
    public bool Ended;

    public bool DisableMovement = false;

	// Update is called once per frame
	public void Update () {
        if (DisableMovement)
        {
            return;
        }

        // Reset
        Began = false;
        Moved = false;
        Stationary = false;
        Ended = false;

        // Get Input
	    if (Input.touchCount > 0) {
            var phase = Input.GetTouch(0).phase;
            switch (phase)
            {
                case TouchPhase.Began:
                    Began = true;
                    break;
                case TouchPhase.Moved:
                    Moved = true;
                    break;
                case TouchPhase.Stationary:
                    Stationary = true;
                    break;
                case TouchPhase.Ended:
                    Ended = true;
                    break;
            }
	    }
        // Debug Mouse
        if (Debug.isDebugBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Began = true;
            }
            else if (Input.GetMouseButton(0))
            {
                Stationary = true;
                Moved = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Ended = true;
            }    
        }
	}
}
