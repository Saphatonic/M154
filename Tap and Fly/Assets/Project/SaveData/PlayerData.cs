using UnityEngine;
using System;

[Serializable]
public class PlayerData  {
    public int Highscore;
    public int Coins;
    public float MasterVolume;
    public float MusicVolume;
	public int AvatarId; 

	public PlayerData()
	{
		Highscore = 0;
		Coins = 0;
		MasterVolume = 1;
		MusicVolume = 1;
		AvatarId = 0;
	}
}
