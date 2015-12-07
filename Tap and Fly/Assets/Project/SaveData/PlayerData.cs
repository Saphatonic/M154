using UnityEngine;
using System;

[Serializable]
public class PlayerData  {
    public int Highscore;
    public int Coins;
    public float MasterVolume;
    public float MusicVolume;
	public int PlayerId; 

	public PlayerData()
	{
		Highscore = 0;
		Coins = 0;
		MasterVolume = 1;
		MusicVolume = 1;
		PlayerId = 0;
	}
}
