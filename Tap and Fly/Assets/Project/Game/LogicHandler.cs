using UnityEngine;
using System.Collections;

public class LogicHandler : MonoBehaviour {

    public GameObject GroundCollider;
    public GameObject InputHandler;
    public GameObject Player;
    private bool _end;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (_end)
        {
            EndGame();
            return;
        }

        if (Player.GetComponent<Player>().IsDead)
        {
            InputHandler.GetComponent<InputHandler>().DisableControls = true;
            _end = true;
            return;
        }
	}

    private void EndGame()
    {

    }
}
