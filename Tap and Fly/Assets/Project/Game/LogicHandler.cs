using UnityEngine;
using System.Collections;

public class LogicHandler : MonoBehaviour {

    public GameObject GroundCollider;
    public GameObject InputHandler;
    public GameObject Player;

    private bool _isDead;
    private bool _end;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        CheckColliders();

        if (_end)
        {
            EndGame();
            return;
        }

        if (_isDead)
        {
            Player.GetComponent<Player>().Die();
            InputHandler.GetComponent<InputHandler>().DisableControls = true;
            _end = true;
            return;
        }
	}

    private void CheckColliders()
    {
        if (GroundCollider.GetComponent<DeathCollider>().IsDead)
        {
            _isDead = true;
        }
    }

    private void EndGame()
    {

    }
}
