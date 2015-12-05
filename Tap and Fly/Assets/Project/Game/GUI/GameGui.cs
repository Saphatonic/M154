using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGui : MonoBehaviour {

    public GameObject Player;
    public Text ScoreText;
	
	// Update is called once per frame
	void Update () {
	    ScoreText.text = Player.GetComponent<Player>().Score.ToString();
	}
}
