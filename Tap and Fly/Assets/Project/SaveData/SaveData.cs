using UnityEngine;
using UnityEditor.Animations;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData : MonoBehaviour {
    
    [HideInInspector]
    public static SaveData Instance { get; private set; }
	// Instance
    public PlayerData PlayerData;
	//	Shop 
	public AvailablePlayer[] AvailablePlayers;

	private string _filePath;

	void Awake () {
        DontDestroyOnLoad(this);
        _filePath = Application.persistentDataPath + "/savedata.dat";
        Load();

        Instance = this;
	}

    private void Load()
    {
        if (File.Exists(_filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(_filePath, FileMode.Open, FileAccess.Read);
            PlayerData =(PlayerData) bf.Deserialize(file);

            AudioListener.volume = PlayerData.MasterVolume;

            file.Close();
        }
        else
        {
            PlayerData = new PlayerData();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(_filePath, FileMode.OpenOrCreate, FileAccess.Write);

        bf.Serialize(file, PlayerData);
        file.Close();
    }
}

[Serializable]
public class AvailablePlayer
{
	public AnimatorController Animator;
	public Sprite Sprite;
}
