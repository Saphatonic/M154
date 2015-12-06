using UnityEngine;
using System.Collections;

public class LogicHandler : MonoBehaviour {

    public GameObject GroundCollider;
    public GameObject InputHandler;
    public GameObject Player;
    public GameObject Tutorial;

    private bool _start;

	// Use this for initialization
	void Start () {
        _start = true;
        PauseGame();
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.GetComponent<Player>().IsDead)
        {
            EndGame();
            return;
        }

        if (_start)
        {
            if (InputHandler.GetComponent<InputHandler>().SingleTouch.Began)
            {
                StartGame();
            }

            return;
        }
	}


    public void ContinueGame()
    {
        Player.GetComponent<Rigidbody2D>().isKinematic = false;
        Player.GetComponent<Player>().enabled = true;
    }

    public void PauseGame()
    {
        Player.GetComponent<Rigidbody2D>().isKinematic = true;
        Player.GetComponent<Player>().enabled = false;
    }

    private void StartGame()
    {
        ContinueGame();

        Destroy(Tutorial);
        Player.GetComponent<Player>().Tap();
        _start = false;
    }

    private void EndGame()
    {

    }
}
