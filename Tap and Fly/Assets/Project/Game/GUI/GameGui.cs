using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGui : MonoBehaviour {

    public Player Player;
    public Text CoinText;
    public Text ScoreText;
    public Text EndScreenText;
    public Text Highscore;

    public Image NewHighscore;
    public Image Medal;
    public Sprite[] AvailableMedals;

    private bool saved;

    public void Start()
    {
        NewHighscore.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = EndScreenText.text = Player.Score.ToString();
        CoinText.text = Player.Coins.ToString();

        if (Player.IsDead && !saved)
        {
            SetHighscore();
            ShowMedal();

            SaveData.Instance.PlayerData.Coins = Player.Coins;
            SaveData.Instance.Save();
            saved = true;
        }
	}

    private void SetHighscore()
    {
        if (Player.Score > SaveData.Instance.PlayerData.Highscore)
        {
            SaveData.Instance.PlayerData.Highscore = Player.Score;
            NewHighscore.enabled = true;
        }

        Highscore.text = SaveData.Instance.PlayerData.Highscore.ToString();
    }

    private void ShowMedal()
    {
        if(Player.Score < 10){
            Medal.sprite = AvailableMedals[0]; 
        } 
        else if(Player.Score < 25){
            Medal.sprite = AvailableMedals[1];
        }
        else
        {
            Medal.sprite = AvailableMedals[2];
        }
    }
}
