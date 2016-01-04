using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData : MonoBehaviour {
    
    [HideInInspector]
    public static SaveData Instance { get; private set; }
	// Instance
    public PlayerData PlayerData;
	//	Shop 
	public List<AvailablePlayer> AvailablePlayers;

	private string _filePath;
    private const float _version = 0.43f;

	void Awake () {
        DontDestroyOnLoad(this);
        _filePath = Application.persistentDataPath + "/savedata.dat";
        Load();

        Instance = this;
	}

    private void Load()
    {
        if (File.Exists(_filePath) && PlayerPrefs.GetFloat("Version") == _version)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(_filePath, FileMode.Open, FileAccess.Read);
            PlayerData = (PlayerData)bf.Deserialize(file);
            file.Close();

            //Setting MasterVolume
            AudioListener.volume = PlayerData.MasterVolume;
        }
        else
        {
            File.Delete(_filePath);
            PlayerData = new PlayerData();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(_filePath, FileMode.OpenOrCreate, FileAccess.Write);
        bf.Serialize(file, PlayerData);
        file.Close();

        //PlayerPrefs
        PlayerPrefs.SetFloat("Version", _version);
    }
}

[Serializable]
public class AvailablePlayer
{
	public string Animator;
	public Sprite Sprite;
    public string Name;
    public int Price;
}