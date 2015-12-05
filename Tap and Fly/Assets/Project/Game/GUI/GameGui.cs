using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGui : MonoBehaviour {

    public GameObject Player;
    public Text ScoreText;
    public Text EndScreenText;
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = EndScreenText.text = Player.GetComponent<Player>().Score.ToString();
	}
}
