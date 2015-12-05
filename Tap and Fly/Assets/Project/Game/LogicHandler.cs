﻿using UnityEngine;
using System.Collections;

public class LogicHandler : MonoBehaviour {

    public GameObject GroundCollider;
    public GameObject InputHandler;
    public GameObject Player;
    public GameObject Tutorial;

    private bool _start;
    private bool _end;

	// Use this for initialization
	void Start () {
        _start = true;
        PauseGame();
	}
	
	// Update is called once per frame
	void Update () {

        if (_end)
        {
            EndGame();
            return;
        }

        if (_start)
        {
            if (InputHandler.GetComponent<InputHandler>().SingleTouch.Began)
            {
                ContinueGame();

                Tutorial.GetComponent<SpriteRenderer>().enabled = false;
                Player.GetComponent<Player>().Tap();
                _start = false;
            }

            return;
        }

        if (Player.GetComponent<Player>().IsDead)
        {
            InputHandler.GetComponent<InputHandler>().DisableControls = true;
            _end = true;
            return;
        }
	}


    public void ContinueGame()
    {
        Player.GetComponent<Player>().enabled = true;
        Player.GetComponent<Rigidbody2D>().WakeUp();
    }

    public void PauseGame()
    {
        Player.GetComponent<Player>().enabled = false;
        Player.GetComponent<Rigidbody2D>().Sleep();
    }

    private void EndGame()
    {

    }
}
