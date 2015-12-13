using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData  {
    public int Highscore;
    public int Coins;
    public float MasterVolume;
    public float MusicVolume;
	public int PlayerId;
    public List<int> OwnedSkins;

	public PlayerData()
	{
		Highscore = 0;
		Coins = 0;
		MasterVolume = 1;
		MusicVolume = 1;
		PlayerId = 0;
        OwnedSkins = new List<int>();
        OwnedSkins.Add(PlayerId);
	}
}
