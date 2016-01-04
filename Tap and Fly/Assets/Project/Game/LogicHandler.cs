using UnityEngine;
using System.Collections;

public class LogicHandler : MonoBehaviour {

    public GameObject GroundCollider;
    public GameObject InputHandler;
    public GameObject Player;
    public GameObject Tutorial;

    public bool IsStart;
    public bool Paused;

	// Use this for initialization
	void Start () {
        IsStart = true;
        PauseGame();
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.GetComponent<Player>().IsDead)
        {
            EndGame();
            return;
        }

        if (IsStart)
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
        Player.GetComponent<Animator>().enabled = true;

        Paused = false;
    }

    public void PauseGame()
    {
        Player.GetComponent<Rigidbody2D>().isKinematic = true;
        Player.GetComponent<Player>().enabled = false;
        Player.GetComponent<Animator>().enabled = false;

        Paused = true;
    }

    private void StartGame()
    {
        ContinueGame();

        Destroy(Tutorial);
        Player.GetComponent<Player>().Tap();
        IsStart = false;
    }

    private void EndGame()
    {
		Paused = true;
    }
}
