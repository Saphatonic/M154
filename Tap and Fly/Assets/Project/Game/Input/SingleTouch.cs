using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SingleTouch
{
    public bool Began;
    public bool Moved;
    public bool Stationary;
    public bool Ended;

    public void Update()
    {
        // Reset
        Began = false;
        Moved = false;
        Stationary = false;
        Ended = false;

        if (Input.touchCount > 0)
        {
            Update(Input.GetTouch(0));
        }

        if (Debug.isDebugBuild)
        {
            DebugUpdate();
        }
    }

    // Update is called once per frame
    public void Update(Touch touch)
    {
        // Is Touch over UI
        int pointerID = touch.fingerId;
        if (EventSystem.current.IsPointerOverGameObject(pointerID))
        {
            return;
        }

        var phase = touch.phase;
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

    public void DebugUpdate()
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
